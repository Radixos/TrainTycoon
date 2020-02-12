using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum workers
{
    Male1, Male2
}

public class HireBuyButtonPress : MonoBehaviour
{
    MakeTrain BuyTrainScript;
    MakeWorker HireWorkerScript;

    GameObject ob;

    private double moneyAmount;

    public double OnHireBuyButtonPress(string temp)
    {
        //HireWorkerScript.workerDict
        return moneyAmount;
    }

    private void Start()
    {
        BuyTrainScript = GetComponentInParent<MakeTrain>();
        HireWorkerScript = GetComponentInParent<MakeWorker>();
    }
}
