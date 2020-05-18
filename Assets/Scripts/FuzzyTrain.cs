using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuzzyTrain : MonoBehaviour
{
    public AnimationCurve SE_small;
    public AnimationCurve SE_medium;
    public AnimationCurve SE_big;

    private float SE_smallValue = 0f;
    private float SE_mediumValue = 0f;
    private float SE_bigValue = 0f;

    public AnimationCurve ToT_short;
    public AnimationCurve ToT_medium;
    public AnimationCurve ToT_long;

    private float ToT_shortValue = 0f;
    private float ToT_mediumValue = 0f;
    private float ToT_longValue = 0f;

    public AnimationCurve TP_cheap;
    public AnimationCurve TP_expensive;

    private float TP_cheapValue = 0f;
    private float TP_expensiveValue = 0f;

    public AnimationCurve C_low;
    public AnimationCurve C_high;

    private float C_lowValue = 0f;
    private float C_highValue = 0f;

    public Slider ticketPriceSlider;
    public TextMeshProUGUI timeOfTravelText;

    public TextMeshProUGUI staffGoodText;
    public TextMeshProUGUI staffOKText;
    public TextMeshProUGUI staffBadText;

    public TextMeshProUGUI passengersGoodText;
    public TextMeshProUGUI passengersOKText;
    public TextMeshProUGUI passengersBadText;

    public TMP_ColorGradient green;
    public TMP_ColorGradient gold;
    public TMP_ColorGradient red;

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
        staffGoodText.enabled = false;
        staffOKText.enabled = false;
        staffBadText.enabled = false;

        passengersGoodText.enabled = false;
        passengersOKText.enabled = false;
        passengersBadText.enabled = false;

        ticketPriceSlider.wholeNumbers = true;
    }

    public void FuzzyStaffHappiness()
    {
        float[] staffHappinessRules = { 100f, 0f, -100f };

        ToT_shortValue = ToT_short.Evaluate(TrainSystem.instance.timeOfTravel);
        ToT_mediumValue = ToT_medium.Evaluate(TrainSystem.instance.timeOfTravel);
        ToT_longValue = ToT_long.Evaluate(TrainSystem.instance.timeOfTravel);
        
        float[] activityDegree = { ToT_shortValue, ToT_mediumValue, ToT_longValue };

        float numerator = 0f;
        float denumerator = 0f;

        for (int i = 0; i < staffHappinessRules.Length; i++)
        {
            numerator += activityDegree[i] * staffHappinessRules[i];
            denumerator += activityDegree[i];
        }

        //LevelManager.instance.staffHappiness += (int)(((((numerator / denumerator) + LevelManager.instance.staffBonusSlider.value - (-150f)) / (150f - (-150f))) * (25f + 25f)) - 25f);
        LevelManager.instance.staffHappiness += (int)(LevelManager.instance.Scale((numerator / denumerator) + LevelManager.instance.staffBonusSlider.value, -150f, 150f, -25f, 25f));
        //Debug.Log("Result of FuzzyStaffHappiness: " + ((int)((((((numerator / denumerator + LevelManager.instance.staffBonusSlider.value) - (-150f)) / (150f - (-150f))) * (25f + 25f)) - 25f))));
        //Debug.Log("SH N/D: " + ((int)((numerator / denumerator) + LevelManager.instance.staffBonusSlider.value)));
    }

    public void FuzzyPassengersHappiness()
    {
        float[] passengersHappinessRules = { 100f, 60f, 20f, -20f, -60f, -100f };

        // 1, 1 then 100
        // 2, 1 then 80
        // 3, 1 then 60
        // 1, 2 then 40
        // 2, 2 then 20
        // 3, 2 then 0

        ToT_shortValue = ToT_short.Evaluate(TrainSystem.instance.timeOfTravel);
        ToT_mediumValue = ToT_medium.Evaluate(TrainSystem.instance.timeOfTravel);
        ToT_longValue = ToT_long.Evaluate(TrainSystem.instance.timeOfTravel);

        float[] ToT_activityDegree = { ToT_shortValue, ToT_mediumValue, ToT_longValue };

        TP_cheapValue = TP_cheap.Evaluate(TrainSystem.instance.ticketPriceSlider.value);
        TP_expensiveValue = TP_expensive.Evaluate(TrainSystem.instance.ticketPriceSlider.value);

        float[] TP_activityDegree = { TP_cheapValue, TP_expensiveValue };

        float numerator = 0f;
        float denumerator = 0f;
        int k = 0;

        for (int i = 0; i < TP_activityDegree.Length; i++)
        {
            for (int j = 0; j < ToT_activityDegree.Length; j++)
            {
                numerator += ToT_activityDegree[j] * TP_activityDegree[i] * passengersHappinessRules[k++];
                denumerator += ToT_activityDegree[j] * TP_activityDegree[i];
            }
        }

        //LevelManager.instance.passengersHappiness += (int)(((((numerator / denumerator) - (-100)) / (100 - (-100))) * (25 + 25)) - 25);
        LevelManager.instance.passengersHappiness += (int)(LevelManager.instance.Scale(numerator / denumerator, -100f, 100f, -25f, 25f));
        //Debug.Log("Result of FuzzyPassengersHappiness: " + ((int)(((((numerator / denumerator) - (-100)) / (100 - (-100))) * (25 + 25)) - 25)));
        //Debug.Log("PH N/D: " + ((int)(numerator / denumerator)));
    }

    public IEnumerator EvaluateStaffHappiness() //Or should I make it a "void"???
    {
        staffGoodText.enabled = false;
        staffOKText.enabled = false;
        staffBadText.enabled = false;

        if (LevelManager.instance.staffHappiness < 35)
        {
            staffBadText.enabled = true;
            staffBadText.GetComponent<TextMeshProUGUI>().colorGradientPreset = red;
            yield return new WaitForSeconds(5); //f???
            staffBadText.enabled = false;
        }
        else if (LevelManager.instance.staffHappiness >= 35 && LevelManager.instance.staffHappiness <= 65)
        {
            staffOKText.enabled = true;
            staffBadText.GetComponent<TextMeshProUGUI>().colorGradientPreset = gold;
            yield return new WaitForSeconds(5); //f???
            staffOKText.enabled = false;
        }
        else if (LevelManager.instance.staffHappiness > 65)
        {
            staffGoodText.enabled = true;
            staffBadText.GetComponent<TextMeshProUGUI>().colorGradientPreset = green;
            yield return new WaitForSeconds(5); //f???
            staffGoodText.enabled = false;
        }
    }

    public IEnumerator EvaluatePassengersHappiness()
    {
        passengersGoodText.enabled = false;
        passengersOKText.enabled = false;
        passengersBadText.enabled = false;

        if (LevelManager.instance.passengersHappiness < 35)
        {
            passengersBadText.enabled = true;
            passengersBadText.GetComponent<TextMeshProUGUI>().colorGradientPreset = red;
            yield return new WaitForSeconds(5); //f???
            passengersBadText.enabled = false;
        }
        else if (LevelManager.instance.passengersHappiness >= 35 && LevelManager.instance.passengersHappiness <= 65)
        {
            passengersOKText.enabled = true;
            passengersBadText.GetComponent<TextMeshProUGUI>().colorGradientPreset = gold;
            yield return new WaitForSeconds(5); //f???
            passengersOKText.enabled = false;
        }
        else if (LevelManager.instance.passengersHappiness > 65)
        {
            passengersGoodText.enabled = true;
            passengersBadText.GetComponent<TextMeshProUGUI>().colorGradientPreset = green;
            yield return new WaitForSeconds(5); //f???
            passengersGoodText.enabled = false;
        }
    }
}