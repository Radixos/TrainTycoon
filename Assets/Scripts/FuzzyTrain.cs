using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuzzyTrain : MonoBehaviour
{
    public AnimationCurve SE_small;
    public AnimationCurve SE_medium;
    public AnimationCurve SE_big;

    public AnimationCurve ToT_short;
    public AnimationCurve ToT_long;

    public AnimationCurve TP_cheap;
    public AnimationCurve TP_expensive;

    public AnimationCurve C_low;
    public AnimationCurve C_high;

    public Slider ticketPriceSlider;
    public TMPro.TextMeshProUGUI timeOfTravelText;

    TrainSystem TrainSystemScript;

    #region FakeSingleton
    public static FuzzyTrain instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    private void Start()
    {
        ticketPriceSlider.minValue = 0f;
        ticketPriceSlider.maxValue = 250f;
        ticketPriceSlider.wholeNumbers = true;
        ticketPriceSlider.value = 125f;

        TrainSystemScript = GetComponentInParent<TrainSystem>();
    }

    public void ReadTimeOfTravel()
    {
        if(timeOfTravelText.text == "Wrong destination")
        {
            Debug.Log("Time read problem - wrong destination problem");
        }
        else
        {
            //Debug.Log(/*"Time of travel: " + */TrainSystemScript.timeOfTravel);
        }
    }

    public void EvaluateStaffHappiness()
    {
        
    }

    public void EvaluateTravellersHappiness()
    {
        //(ticketPriceSlider.value / 250f);
    }

    public void EvaluateProfitHappiness()
    {

    }

    public void EvaluateTravellingAttractiveness()
    {

    }

    public void EvaluateStaffEfficiency()
    {

    }

    public void Update()
    {
        ReadTimeOfTravel();
    }
}