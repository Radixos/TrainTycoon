using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DispatchTrain : MonoBehaviour
{
    public Slider ticketPriceSlider;
    public Slider staffBonusSlider;
    public Toggle foodAndDrinks;


    public TextMeshProUGUI staffHappinessText;

    public GameObject UI;

    private float factor = 0f;
    private float tempStaffBonus = 0f;
    private int staffHappiness = 50;

    TrainSystem TrainSystemScript;

    void Start()
    {
        TrainSystemScript = UI.GetComponent<TrainSystem>();
    }

    void Update()
    {
        //EvaluateVariables();
        //EvaluateStaffHappiness();
        LevelManager.instance.staffHappiness += (int)staffBonusSlider.value;
        LevelManager.instance.UpdateStaffHappinessDisplay();
        LevelManager.instance.staffHappiness = 50;

        //TODO: FIX EQUATION BELOW
        //if(TrainSystemScript.timeOfTravel.GetType() != "string")
        LevelManager.instance.passengersHappiness += (((-((int)ticketPriceSlider.value + 25)/(25+25)) * 10) + ((-(TrainSystemScript.timeOfTravel + 25)/(25+25)) * 10));
        //Debug.Log(TrainSystemScript.timeOfTravel);
        LevelManager.instance.UpdatePassengersHappinessDisplay();
        LevelManager.instance.passengersHappiness = 50;
    }

    void EvaluateVariables()
    {
        tempStaffBonus = staffBonusSlider.value / 50f;

        if (foodAndDrinks.isOn)
        {
            factor += 5f;
        }
        else
        {
            factor -= 5f;
        }

        factor += (((-(ticketPriceSlider.value / 250f) * 100f) + (tempStaffBonus * 100f)) /2f) + 20f;
        //Debug.Log(factor);
        factor = 0f;
    }

    void ConfirmDispatch()
    {
        //if (Male1.GetComponent<Button>().onClick.AddListener(StaffPick))
    }


}
