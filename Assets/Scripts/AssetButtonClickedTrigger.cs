using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//TODO: Make if in Update work when a specific ChooseAsset button is pressed

public class AssetButtonClickedTrigger : MonoBehaviour
{
    public UnityEvent ButtonsToTrigger;
    public GameObject panel;
    private bool isActive;

    void Start()
    {
        //ButtonsToTrigger.Invoke();
        isActive = panel.activeSelf;
    }

    void Update()
    {
        //while(true)
        //{
        //    ButtonsToTrigger.Invoke();
        //}
        if (panel != null)
        {
            if (isActive == true && Input.GetKeyDown(KeyCode.Mouse0))
            {
                ButtonsToTrigger.Invoke();
            }
        }
    }
}
