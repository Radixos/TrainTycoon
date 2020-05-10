using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public double moneyAmount;
    public TextMeshProUGUI moneyAmountText;

    //public double profit;
    //public TextMeshProUGUI profitText;

    public int numberOfPassengers = 500;
    public int perPassengerCost = 50;
    public int fuelCost = 10000;

    [HideInInspector] public int waitTime;

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
        yield return new WaitForSeconds(waitTime);
        //yield return null;

        moneyAmount = moneyAmount + (numberOfPassengers * FuzzyTrain.instance.ticketPriceSlider.value - perPassengerCost) - fuelCost
            /*time perPassengerCost and fuelCost by clamped time of travel*/ - AssetsPurchasedController.instance.staffEarnings;
        moneyAmountText.text = moneyAmount.ToString();
        Debug.Log("CalculateEarnings finished");
    }

    public void UpdateMoneyDisplay()
    {
        moneyAmountText.text = moneyAmount.ToString()/* + " £"*/;
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
