using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BuyHirePressed : MonoBehaviour
{
    public GameObject go;
    public TextMeshProUGUI assetsAmount;
    MakeTrain MakeTrainScript;
    MakeWorker MakeWorkerScript;
    private double price;
    private bool functionIsTriggered = false;

    public double UIButtonPressed()
    {
        switch (go.name)
        {
            case "Buy1":
                price = MakeTrainScript.Train1.Price;
                StartCoroutine(LevelManager.instance.TrainAssetBoughtMessage());
                break;
            case "Buy2":
                price = MakeTrainScript.Train2.Price;
                StartCoroutine(LevelManager.instance.TrainAssetBoughtMessage());
                break;
            case "Buy3":
                price = MakeTrainScript.Train3.Price;
                StartCoroutine(LevelManager.instance.TrainAssetBoughtMessage());
                break;
            case "Hire1":
                price = MakeWorkerScript.Female1.Earnings;
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire2":
                price = MakeWorkerScript.Female2.Earnings;
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire3":
                price = MakeWorkerScript.Female3.Earnings;
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire4":
                price = MakeWorkerScript.Male1.Earnings;
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire5":
                price = MakeWorkerScript.Male2.Earnings;
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire6":
                price = MakeWorkerScript.Male3.Earnings;
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
        }

        functionIsTriggered = true;
        return price;
    }

    private void UpdateAssetsAmount()
    {
        int temp = int.Parse(assetsAmount.text);
        temp++;
        assetsAmount.text = temp.ToString();
    }

    public void UpdateMoney()
    {
        if(LevelManager.instance.moneyAmount - UIButtonPressed() >= 0)  //or price instead of UIButtonPressed
        {
            LevelManager.instance.moneyAmount -= UIButtonPressed();
            UpdateAssetsAmount();
        }
        else
        {
            Debug.Log("UpdateMoney function error");
        }
    }

    void Awake()
    {
        assetsAmount.text = "0";

        MakeTrainScript = GetComponentInParent<MakeTrain>();
        MakeWorkerScript = GetComponentInParent<MakeWorker>();
    }

    private void Start()
    {
        //trainAssetBought.GetComponent<TextMeshProUGUI>().enabled = false;
        //staffAssetBought.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    void Update()
    {
        if(functionIsTriggered == true)
        {
            //LevelManager.instance.moneyAmount -= Price;
            LevelManager.instance.UpdateMoneyDisplay();
            functionIsTriggered = false;
        }
    }
}
