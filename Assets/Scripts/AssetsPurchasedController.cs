﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: To finish this class after implementing dispatch train panel

public class AssetsPurchasedController : MonoBehaviour
{
    HireWorker HireWorkerScript;

    private bool trainAvailable;
    private bool workerAvailable;

    private bool CanTrainBeDispatched()
    {
        if (trainAvailable == true && workerAvailable == true)
            return true;

        Debug.Log("Train can not be dispatched.");
        return false;
    }

    private void Start()
    {
        HireWorkerScript = GetComponentInParent<HireWorker>();
    }

    void Update()
    {
        CanTrainBeDispatched();
    }
}