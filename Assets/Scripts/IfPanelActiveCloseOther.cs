using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IfPanelActiveCloseOther : MonoBehaviour
{
    public GameObject panelToActive;
    public GameObject panelToClose;

    public GameObject sendFrom;
    public GameObject sendTo;

    private bool panelToActiveActive;
    private bool panelToCloseActive;

    public void OpenPanel()
    {
        //if (panelToActive != null && panelToClose != null)
        //{
        //    panelToCloseActive = panelToClose.activeSelf;
        //    panelToClose.SetActive(panelToCloseActive);
        //    Debug.Log(panelToClose.activeSelf);

        //    if (!panelToClose.activeSelf)
        //    {
        //        panelToActiveActive = panelToActive.activeSelf;
        //        panelToActive.SetActive(!panelToActiveActive);
        //    }
        //}

        if (panelToActive != null && panelToClose != null)
        {
            if (sendFrom.GetComponentInChildren<TMP_Dropdown>().value
                != sendTo.GetComponentInChildren<TMP_Dropdown>().value)
            {
                panelToCloseActive = panelToClose.activeSelf;
                panelToClose.SetActive(panelToCloseActive);
                //if (panelToCloseActive)
                //{
                panelToActiveActive = panelToActive.activeSelf;
                panelToActive.SetActive(!panelToActiveActive);
                //}
            }
        }
    }
}