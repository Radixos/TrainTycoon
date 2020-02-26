using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
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

    public double moneyAmount;
    public TextMeshProUGUI moneyAmountText;

    private void Start()
    {
        UpdateMoneyDisplay(); 
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
