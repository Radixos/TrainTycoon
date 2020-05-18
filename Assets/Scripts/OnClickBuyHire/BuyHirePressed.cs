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
    private double Price;
    private bool functionIsTriggered = false;

    public double UIButtonPressed()
    {
        switch (go.name)
        {
            case "Buy1":
                Price = MakeTrainScript.Train1.Price;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.TrainAssetBoughtMessage());
                break;
            case "Buy2":
                Price = MakeTrainScript.Train2.Price;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.TrainAssetBoughtMessage());
                break;
            case "Buy3":
                Price = MakeTrainScript.Train3.Price;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.TrainAssetBoughtMessage());
                break;
            case "Hire1":
                Price = MakeWorkerScript.Female1.Earnings;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire2":
                Price = MakeWorkerScript.Female2.Earnings;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire3":
                Price = MakeWorkerScript.Female3.Earnings;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire4":
                Price = MakeWorkerScript.Male1.Earnings;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire5":
                Price = MakeWorkerScript.Male2.Earnings;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
            case "Hire6":
                Price = MakeWorkerScript.Male3.Earnings;
                UpdateAssetsAmount();
                StartCoroutine(LevelManager.instance.StaffAssetBoughtMessage());
                break;
        }

        functionIsTriggered = true;
        return Price;
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
        if(LevelManager.instance.moneyAmount - Price >= 0)
        {
            LevelManager.instance.moneyAmount -= UIButtonPressed();
            //Debug.Log("I should update!");
        }
        else
        {
            Debug.Log("UpdateMoney function error");
        }
    }

    void Awake()
    {
        //if (trainAssetBought != null && trainAssetBought.enabled == true)
        //{
        //trainAssetBought.enabled = false;
        //}

        //if (staffAssetBought != null && staffAssetBought.enabled == true)
        //{
        //staffAssetBought.enabled = false;
        //}

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
