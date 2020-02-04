using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using "Assets\Scripts\TrainSystem.cs";

public class MoneyDisplay : MonoBehaviour
{
    private float moneyAmount = 50000f;
    public TMPro.TextMeshProUGUI MoneyAmountText;
    
    void Update()
    {
        MoneyAmountText.text = moneyAmount.ToString() + " £";

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //Input.GetButtonDown
            moneyAmount -= 100f;
        }
    }
}
