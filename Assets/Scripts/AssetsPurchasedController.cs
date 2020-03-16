using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: To finish this class after implementing dispatch train panel

public class AssetsPurchasedController : MonoBehaviour
{
    MakeWorker HireWorkerScript;

    //private bool trainAvailable;
    //private bool workerAvailable;

    //private bool CanTrainBeDispatched()
    //{
        //if (trainAvailable == true && workerAvailable == true)
        //{
        //    Debug.Log("Train can be dispatched");
        //    return true;
        //}
        //else
        //{
        //    Debug.Log("Train can not be dispatched. Not enough assets.");
        //    return false;
        //}
    //}

    private void Start()
    {
        HireWorkerScript = GetComponentInParent<MakeWorker>();
    }

    void Update()
    {
        //CanTrainBeDispatched();
    }
}
