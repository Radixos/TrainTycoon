using System.Collections;
using UnityEngine;

public class OnMouseHover : MonoBehaviour
{
    public GameObject panel;
    public Camera mainCamera;

    public void Start()
    {
        bool isActive = panel.activeSelf;
        panel.SetActive(isActive);
    }

    public void OnMouseIsOver()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
}
