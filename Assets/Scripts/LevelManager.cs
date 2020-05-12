using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public double moneyAmount;
    public TextMeshProUGUI moneyAmountText;

    public double profit;
    public TextMeshProUGUI profitText;

    public int numberOfPassengers = 500;
    public int perPassengerCost = 75;
    public int fuelCost = 20000;

    //[HideInInspector] public int waitTime;

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
        UpdateMoneyDisplay();
    }
    public IEnumerator CalculateEarnings(int waitTime)
    {
        Debug.Log("CalculateEarnings called");
        Debug.Log(waitTime);

        //float counter = 0;
        //while (counter < waitTime)
        //{
        //    //Increment Timer until counter >= waitTime
        //    counter += Time.deltaTime;
        //    Debug.Log("We have waited for: " + counter + " seconds");
        //    //Wait for a frame so that Unity doesn't freeze
        //    //Check if we want to quit this function
        //    if (counter >= waitTime)
        //    {
        //        //Quit function
        //        yield break;
        //    }
        //    yield return null;
        //}

        yield return new WaitForSeconds(waitTime);  //Does not work correctly - wait time is always 0
        //yield return null;
        profit = (numberOfPassengers * FuzzyTrain.instance.ticketPriceSlider.value - (perPassengerCost * Mathf.Clamp(waitTime, 1, 2))) - (fuelCost * Mathf.Clamp(waitTime, 1, 2))
            /*time perPassengerCost and fuelCost by clamped time of travel*/ - AssetsPurchasedController.instance.staffEarnings;    //check if clamps work correctly
        UpdateProfitDisplay();
        moneyAmount += profit;
        UpdateMoneyDisplay();
        Debug.Log("CalculateEarnings finished");
    }

    public void UpdateMoneyDisplay()
    {
        moneyAmountText.text = moneyAmount.ToString()/* + " £"*/;
    }

    public void UpdateProfitDisplay()
    {
        profitText.text = "Profit: " + profit.ToString() + " £";
    }

    public int staffHappiness = 50;
    public TextMeshProUGUI staffHappinessText;

    public void UpdateStaffHappinessDisplay()
    {
        staffHappinessText.text = staffHappiness.ToString();
    }

    public int passengersHappiness = 50;
    public TextMeshProUGUI passengersHappinessText;

    public void UpdatePassengersHappinessDisplay()
    {
        passengersHappinessText.text = passengersHappiness.ToString();
    }

    //public int timeOfTravel = 0;
    //public TextMeshProUGUI timeOfTravelText;

    //public void UpdateTimeOfTravelDisplay()
    //{
    //    timeOfTravelText.text = timeOfTravel.ToString();
    //}
}
