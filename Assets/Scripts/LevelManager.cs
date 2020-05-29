using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public double moneyAmount = 35000;
    public TextMeshProUGUI moneyAmountText;

    public GameObject lostMessage;

    public double profit;
    public TextMeshProUGUI profitText;

    public double costOfDispatch;
    public TextMeshProUGUI costOfDispatchText;

    public double passengersTravelling;
    public TextMeshProUGUI passengersTravellingText;

    public int staffHappiness = 50;
    public TextMeshProUGUI staffHappinessText;

    public int passengersHappiness = 50;
    public TextMeshProUGUI passengersHappinessText;

    public int numberOfPassengers = 500;
    public int perPassengerCost = 100;
    public int fuelCost = 20000;
    public int foodCost = 10;

    //timeFactor in AssetsPurchasedController

    public Slider ticketPriceSlider;
    public Slider staffBonusSlider;
    public Toggle foodAndDrinks;

    public TextMeshProUGUI boughtMessageText;
    public TextMeshProUGUI hiredMessageText;

    //public GameObject UI;

    private float factor = 0f;
    private float tempStaffBonus = 0f;

    #region FakeSingleton
    public static LevelManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    private void Start()
    {
        boughtMessageText.enabled = false;
        hiredMessageText.enabled = false;

        UpdateMoneyDisplay();
    }

    public float Scale(float value, float current_min, float current_max, float target_min, float target_max)
    {
        float new_value = (((value - current_min) / (current_max - current_min)) * (target_max - target_min)) + target_min;

        return new_value;
    }

    //TODO: Bug where a player must wait with Panel opened until TrainAssetBoughtMessage closes

    public IEnumerator TrainAssetBoughtMessage()
    {
        if (boughtMessageText != null)
        {
            boughtMessageText.enabled = true;
            yield return new WaitForSeconds(3);
            boughtMessageText.enabled = false;
        }
    }

    //TODO: Bug where a player must wait with Panel opened until StaffAssetBoughtMessage closes

    public IEnumerator StaffAssetBoughtMessage()
    {
        if (hiredMessageText != null)
        {
            hiredMessageText.enabled = true;
            yield return new WaitForSeconds(3);
            hiredMessageText.enabled = false;
        }
    }

    public IEnumerator CalculateEarningsAndHappiness(int waitTime)
    {
        //Debug.Log("CalculateEarnings called");

        int numberOfPassengersToTravel = (int)(numberOfPassengers * (Scale(passengersHappiness, 0f, 100f, 0.5f, 0.95f)));

        //Debug.Log("Scaled number of passengers: " + numberOfPassengersToTravel);

        //Debug.Log("s_trainType: " + AssetsPurchasedController.instance.s_trainType);

        //Can move three below ifs to traintype switch statement further below

        if (AssetsPurchasedController.instance.s_trainType.ToString() == "Train1")
            numberOfPassengersToTravel = (int)Mathf.Clamp(numberOfPassengersToTravel, 0f, (float)MakeTrain.instance.Train1.Capacity);

        if (AssetsPurchasedController.instance.s_trainType.ToString() == "Train2")
            numberOfPassengersToTravel = (int)Mathf.Clamp(numberOfPassengersToTravel, 0f, (float)MakeTrain.instance.Train2.Capacity);

        if (AssetsPurchasedController.instance.s_trainType.ToString() == "Train3")
            numberOfPassengersToTravel = (int)Mathf.Clamp(numberOfPassengersToTravel, 0f, (float)MakeTrain.instance.Train3.Capacity);

        passengersTravelling = numberOfPassengersToTravel;

        double staffHappinnesBonus = 1;
        double staffSpeedBonus = 1;

        switch (AssetsPurchasedController.instance.s_staffType.ToString())
        {
            case "Male1":
                staffHappinnesBonus = MakeWorker.instance.Male1.HappinessBonus;
                staffSpeedBonus = MakeWorker.instance.Male1.SpeedBonus;
                break;
            case "Male2":
                staffHappinnesBonus = MakeWorker.instance.Male2.HappinessBonus;
                staffSpeedBonus = MakeWorker.instance.Male2.SpeedBonus;
                break;
            case "Male3":
                staffHappinnesBonus = MakeWorker.instance.Male3.HappinessBonus;
                staffSpeedBonus = MakeWorker.instance.Male3.SpeedBonus;
                break;
            case "Female1":
                staffHappinnesBonus = MakeWorker.instance.Female1.HappinessBonus;
                staffSpeedBonus = MakeWorker.instance.Female1.SpeedBonus;
                break;
            case "Female2":
                staffHappinnesBonus = MakeWorker.instance.Female2.HappinessBonus;
                staffSpeedBonus = MakeWorker.instance.Female2.SpeedBonus;
                break;
            case "Female3":
                staffHappinnesBonus = MakeWorker.instance.Female3.HappinessBonus;
                staffSpeedBonus = MakeWorker.instance.Female3.SpeedBonus;
                break;
        }

        Debug.Log("staffHappinnesBonus: " + staffHappinnesBonus);
        Debug.Log("staffSpeedBonus: " + staffSpeedBonus);

        double trainHappinnesBonus = 1;
        double trainSpeedBonus = 1;

        switch (AssetsPurchasedController.instance.s_trainType.ToString())
        {
            case "Train1":
                trainHappinnesBonus = MakeTrain.instance.Train1.HappinessBonus;
                trainSpeedBonus = MakeTrain.instance.Train1.SpeedBonus;
                break;
            case "Train2":
                trainHappinnesBonus = MakeTrain.instance.Train2.HappinessBonus;
                trainSpeedBonus = MakeTrain.instance.Train1.SpeedBonus;
                break;
            case "Train3":
                trainHappinnesBonus = MakeTrain.instance.Train3.HappinessBonus;
                trainSpeedBonus = MakeTrain.instance.Train1.SpeedBonus;
                break;
        }

        Debug.Log("trainHappinnesBonus: " + trainHappinnesBonus);
        Debug.Log("trainSpeedBonus: " + trainSpeedBonus);

        //Debug.Log("Actual number of passengers: " + numberOfPassengersToTravel);

        int actualStaffEarnings = (int)(AssetsPurchasedController.instance.staffEarnings * (Scale(staffBonusSlider.value, -50f, 50f, 0.5f, 1.5f)) * staffHappinnesBonus);

        //Debug.Log("Staff bonus: " + actualStaffEarnings);

        costOfDispatch = (perPassengerCost * numberOfPassengersToTravel) + (fuelCost /* * waitTime*/)
            + actualStaffEarnings;
        
        if (foodAndDrinks.isOn)
        {
            staffHappiness += 3;
            passengersHappiness += 3;
            costOfDispatch += foodCost * numberOfPassengersToTravel;
            Debug.Log("Food expenses: " + (foodCost * numberOfPassengersToTravel));
        }
        else
        {
            staffHappiness -= 5;
            passengersHappiness -= 5;
            Debug.Log("Food expenses: None");
        }

        profit = (numberOfPassengersToTravel * FuzzyTrain.instance.ticketPriceSlider.value) - costOfDispatch;
        
        UpdateCostOfDispatchDisplay();
        UpdateProfitDisplay();
        UpdatePassengersTravellingDisplay();

        #region FuzzyStaffHappiness

        FuzzyTrain.instance.FuzzyStaffHappiness();

        Debug.Log("staffHappiness: " + staffHappiness);

        Mathf.Clamp(staffHappiness, 0f, 100f);

        //if (staffHappiness > 100)
        //    staffHappiness = 100;
        //else if (staffHappiness < 0)
        //    staffHappiness = 0;

        UpdateStaffHappinessDisplay();
        #endregion

        #region FuzzyPassengersHappiness

        Debug.Log("passengersHappiness: " + passengersHappiness);

        FuzzyTrain.instance.FuzzyPassengersHappiness();

        Mathf.Clamp(passengersHappiness, 0f, 100f);

        //if (passengersHappiness > 100)
        //    passengersHappiness = 100;
        //else if (passengersHappiness < 0)
        //    passengersHappiness = 0;

        UpdatePassengersHappinessDisplay();
        #endregion

        yield return new WaitForSeconds(waitTime);
        
        ////////////////////After waitTime////////////////////

        moneyAmount += profit;
        UpdateMoneyDisplay();

        if (moneyAmount < 0)
            lostMessage.SetActive(true);

        //Debug.Log("CalculateEarnings finished");
        //Debug.Log("Displaying fuzzy info finished");
    }

    #region NonFuzzyHappinessUpdate
    //public void UpdateHappinessDisplay()
    //{
    //    if (foodAndDrinks.isOn)
    //    {
    //        staffHappiness += 5;
    //        passengersHappiness += 5;
    //    }
    //    else
    //    {
    //        staffHappiness -= 5;
    //        passengersHappiness -= 5;
    //    }

    //    staffHappiness += ((((int)staffBonusSlider.value + 50) / (50 + 50)) * (25 + 25)) - 25;  //Is it correct?
    //    if (staffHappiness > 100)
    //        staffHappiness = 100;
    //    else if (staffHappiness < 0)
    //        staffHappiness = 0;

    //    UpdateStaffHappinessDisplay();

    //    passengersHappiness -= ((((int)ticketPriceSlider.value - 0) / (250 - 0)) * (25 + 25)) - 25; //Is it correct?
    //    if (passengersHappiness > 100)
    //        passengersHappiness = 100;
    //    else if (passengersHappiness < 0)
    //        passengersHappiness = 0;

    //    UpdatePassengersHappinessDisplay();
    //}
    #endregion

    public void UpdateMoneyDisplay()
    {
        moneyAmountText.text = moneyAmount.ToString()/* + " £"*/;
    }

    public void UpdateProfitDisplay()
    {
        profitText.text = "Profit: " + profit.ToString() + " £";
    }

    public void UpdateCostOfDispatchDisplay()
    {
        costOfDispatchText.text = "Cost of dispatch: " + costOfDispatch.ToString() + " £";
    }

    public void UpdatePassengersTravellingDisplay()
    {
        passengersTravellingText.text = "Passengers Travelling: " + passengersTravelling.ToString();
    }

    public void UpdateStaffHappinessDisplay()
    {
        staffHappinessText.text = "Staff: " + staffHappiness.ToString();
    }

    public void UpdatePassengersHappinessDisplay()
    {
        passengersHappinessText.text = "Passengers: " + passengersHappiness.ToString();
    }
}