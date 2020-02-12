using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//using UnityEngine.EventSystems;

public class BuyHirePressed : MonoBehaviour
{
    public double moneyAmount;
    public GameObject go;
    public TextMeshProUGUI moneyAmountText;
    //public GameObject UI;
    MakeTrain MakeTrainScript;
    MakeWorker MakeWorkerScript;
    MoneyDisplay MoneyText;
    private double Price;
    private bool functionIsTriggered = false;
    //var go = EventSystem.current.currentSelectedGameObject;

    public double UIButtonPressed()
    {
        switch (go.name)
        {
            case "Buy1":
                Price = MakeTrainScript.Train1.Price;
                break;
            case "Buy2":
                Price = MakeTrainScript.Train2.Price;
                break;
            case "Buy3":
                Price = MakeTrainScript.Train3.Price;
                break;
            case "Hire1":
                Price = MakeWorkerScript.Female1.Earnings;
                break;
            case "Hire2":
                Price = MakeWorkerScript.Female2.Earnings;
                break;
            case "Hire3":
                Price = MakeWorkerScript.Female3.Earnings;
                break;
            case "Hire4":
                Price = MakeWorkerScript.Male1.Earnings;
                break;
            case "Hire5":
                Price = MakeWorkerScript.Male2.Earnings;
                break;
            case "Hire6":
                Price = MakeWorkerScript.Male3.Earnings;
                break;
        }

        functionIsTriggered = true;
        return Price;
        //moneyUpdateText.text = MakeTrainScript.Train1.Price + " £";
    }

    public void UpdateMoney()
    {
        moneyAmount -= UIButtonPressed();
        //moneyAmountText.text = /*(MoneyText.moneyAmount - UIButtonPressed())*/(moneyAmount - UIButtonPressed()).ToString();
        Debug.Log("I should update!");
    }

    void Start()
    {
        //moneyAmountText.text = moneyAmount.ToString()/* + " £"*/;
        MakeTrainScript = GetComponentInParent<MakeTrain>();
        MakeWorkerScript = GetComponentInParent<MakeWorker>();
        //MoneyText = UI.GetComponent<MoneyDisplay>();
    }

    void Update()
    {
        if(functionIsTriggered == true)
        {
            moneyAmountText.text = moneyAmount.ToString();
            functionIsTriggered = false;
        }
    }
}
