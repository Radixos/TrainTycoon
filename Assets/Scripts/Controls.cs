using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject controlsPanel;
    public TMPro.TextMeshProUGUI WASDControls;
    public TMPro.TextMeshProUGUI QEControls;
    public TMPro.TextMeshProUGUI RControls;
    public TMPro.TextMeshProUGUI ScrollControls;
    public TMPro.TextMeshProUGUI EndControls;

    private bool[] WASDPressed = { false, false, false, false };
    private bool[] QEPressed = { false, false };
    private bool RPressed = false;
    private bool MMBScrolled = false;
    private bool SpacePressed = false;

    public void WASDTake()
    {
        if (WASDControls != null)
        {

            if (Input.GetKeyDown("w"))
                WASDPressed[0] = true;

            if (Input.GetKeyDown("a"))
                WASDPressed[1] = true;

            if (Input.GetKeyDown("s"))
                WASDPressed[2] = true;

            if (Input.GetKeyDown("d"))
                WASDPressed[3] = true;

            if (WASDPressed[0] && WASDPressed[1] && WASDPressed[2] && WASDPressed[3])
            {
                WASDControls.enabled = false;
                QEControls.enabled = true;
            }
        }
    }

    public void QETake()
    {
        if (QEControls != null)
        {
            if (Input.GetKeyDown("q"))
                QEPressed[0] = true;

            if (Input.GetKeyDown("e"))
                QEPressed[1] = true;

            if (QEPressed[0] && QEPressed[1])
            {
                QEControls.enabled = false;
                RControls.enabled = true;
            }
        }
    }

    public void RTake()
    {
        if (RControls != null)
        {
            if (Input.GetKeyDown("r"))
                RPressed = true;

            if (RPressed)
            {
                RControls.enabled = false;
                ScrollControls.enabled = true;
            }
        }
    }

    public void ScrollTake()
    {
        if (ScrollControls != null)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
                MMBScrolled = true;

            if (MMBScrolled)
            {
                ScrollControls.enabled = false;
                EndControls.enabled = true;
            }
        }
    }

    public void SpaceTake()
    {
        if (EndControls != null)
        {
            if (Input.GetKeyDown("space"))
                SpacePressed = true;

            if (SpacePressed)
                EndControls.enabled = false;
        }
    }

    public void Start()
    {
        WASDControls.enabled = true;
        QEControls.enabled = false;
        RControls.enabled = false;
        ScrollControls.enabled = false;
        EndControls.enabled = false;
    }

    public void Update()
    {
        if (controlsPanel != null)
        {
            bool isActive = controlsPanel.activeSelf;

            WASDTake();
            QETake();
            RTake();
            ScrollTake();
            SpaceTake();

            if(SpacePressed)
                controlsPanel.SetActive(!isActive);
        }
    }
}