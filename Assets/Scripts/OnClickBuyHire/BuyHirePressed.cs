using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//using UnityEngine.EventSystems;

public class BuyHirePressed : MonoBehaviour
{
    public double moneyAmount;
    public GameObject go;
    public TextMeshProUGUI moneyAmountText;
    public TextMeshProUGUI assetsAmount;
    public TextMeshProUGUI trainAssetBought;
    public TextMeshProUGUI staffAssetBought;
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
                UpdateAssetsAmount();
                trainAssetBoughtMessage();
                break;
            case "Buy2":
                Price = MakeTrainScript.Train2.Price;
                UpdateAssetsAmount();
                trainAssetBoughtMessage();
                break;
            case "Buy3":
                Price = MakeTrainScript.Train3.Price;
                UpdateAssetsAmount();
                trainAssetBoughtMessage();
                break;
            case "Hire1":
                Price = MakeWorkerScript.Female1.Earnings;
                UpdateAssetsAmount();
                staffAssetBoughtMessage();
                break;
            case "Hire2":
                Price = MakeWorkerScript.Female2.Earnings;
                UpdateAssetsAmount();
                staffAssetBoughtMessage();
                break;
            case "Hire3":
                Price = MakeWorkerScript.Female3.Earnings;
                UpdateAssetsAmount();
                staffAssetBoughtMessage();
                break;
            case "Hire4":
                Price = MakeWorkerScript.Male1.Earnings;
                UpdateAssetsAmount();
                staffAssetBoughtMessage();
                break;
            case "Hire5":
                Price = MakeWorkerScript.Male2.Earnings;
                UpdateAssetsAmount();
                staffAssetBoughtMessage();
                break;
            case "Hire6":
                Price = MakeWorkerScript.Male3.Earnings;
                UpdateAssetsAmount();
                staffAssetBoughtMessage();
                break;
        }

        functionIsTriggered = true;
        return Price;
        //moneyUpdateText.text = MakeTrainScript.Train1.Price + " £";
    }

    private void trainAssetBoughtMessage()
    {
        if (trainAssetBought != null)
        {
            trainAssetBought.enabled = true;
            Invoke("trainAssetBoughtFN", 3.0f);
        }
    }

    private void trainAssetBoughtFN()
    {
        trainAssetBought.enabled = false;
    }

    private void staffAssetBoughtMessage()
    {
        if (staffAssetBought != null)
        {
            staffAssetBought.enabled = true;
            Invoke("staffAssetBoughtFN", 3.0f);
        }
    }

    private void staffAssetBoughtFN()
    {
        staffAssetBought.enabled = false;
    }

    //TODO: Avoid converting string to number and back to string

    private void UpdateAssetsAmount()
    {
        int temp = int.Parse(assetsAmount.text);
        temp++;
        assetsAmount.text = temp.ToString();
    }

    public void UpdateMoney()
    {
        moneyAmount -= UIButtonPressed();
        //moneyAmountText.text = /*(MoneyText.moneyAmount - UIButtonPressed())*/(moneyAmount - UIButtonPressed()).ToString();
        Debug.Log("I should update!");
    }

    void Start()
    {
        //TODO: fix two ifs below not being called immediately

        if (trainAssetBought != null && trainAssetBought.enabled == true)
        {
            trainAssetBought.enabled = false;
        }

        if (staffAssetBought != null && staffAssetBought.enabled == true)
        {
            staffAssetBought.enabled = false;
        }

        assetsAmount.text = "0";
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
