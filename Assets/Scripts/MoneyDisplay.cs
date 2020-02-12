using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using "Assets\Scripts\TrainSystem.cs";

public class MoneyDisplay : MonoBehaviour
{
    public float moneyAmount = 50000f;
    public TMPro.TextMeshProUGUI moneyAmountDisplayText;
    
    void Update()
    {
        moneyAmountDisplayText.text = moneyAmount.ToString()/* + " £"*/;

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //Input.GetButtonDown
            moneyAmount -= 100f;
        }
    }
}
