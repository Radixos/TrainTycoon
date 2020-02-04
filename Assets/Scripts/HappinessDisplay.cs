using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessDisplay : MonoBehaviour
{
    private float happiness = 50f;
    public TMPro.TextMeshProUGUI HappinessPercentageText;

    void Update()
    {
        HappinessPercentageText.text = happiness.ToString() + " %";

        if(Input.GetKeyDown(KeyCode.Space))
        {
            happiness--;
        }
    }
}
