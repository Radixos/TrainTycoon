using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaffPick : MonoBehaviour
{
    public GameObject currentGO;

    public GameObject Male1;
    public GameObject Male2;
    public GameObject Male3;
    public GameObject Female1;
    public GameObject Female2;
    public GameObject Female3;

    public GameObject Male1Original;
    public GameObject Male2Original;
    public GameObject Male3Original;
    public GameObject Female1Original;
    public GameObject Female2Original;
    public GameObject Female3Original;

    private int Male1Amount;
    private int Male2Amount;
    private int Male3Amount;
    private int Female1Amount;
    private int Female2Amount;
    private int Female3Amount;

    private bool staffPicked = false;

    public TextMeshProUGUI chooseStaff;

    private string staffButtonClickedName;

    private void Start()
    {
        InvokeRepeating("UpdateStaffAssets", 0f, 1f);
    }

    private void Update()
    {
        CHooseStaffText();
    }

    void UpdateStaffAssets()
    {
        if (Male1Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male1.GetComponentInChildren<TextMeshProUGUI>().text = Male1Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Male1Amount = int.Parse(Male1.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Male2Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male2.GetComponentInChildren<TextMeshProUGUI>().text = Male2Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Male2Amount = int.Parse(Male2.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Male3Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male3.GetComponentInChildren<TextMeshProUGUI>().text = Male3Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Male3Amount = int.Parse(Male3.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Female1Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Female1.GetComponentInChildren<TextMeshProUGUI>().text = Female1Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Female1Amount = int.Parse(Female1.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Female2Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Female2.GetComponentInChildren<TextMeshProUGUI>().text = Female2Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Female2Amount = int.Parse(Female2.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Female3Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Female3.GetComponentInChildren<TextMeshProUGUI>().text = Female3Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Female3Amount = int.Parse(Female3.GetComponentInChildren<TextMeshProUGUI>().text);
        }
    }

    public void StaffPickFunction()    //TODO: fix this function and one below
    {
        //staffButtonClickedName = staffButton.name;
        staffButtonClickedName = currentGO.name;

        Debug.Log("Current GO: " + staffButtonClickedName);

        switch (staffButtonClickedName)
        {
            case "Male1N":
                if (Male1Amount > 0)
                {
                    Debug.Log(staffButtonClickedName + " clicked");
                    Male2.GetComponent<Button>().interactable = false;
                    Male3.GetComponent<Button>().interactable = false;
                    Female1.GetComponent<Button>().interactable = false;
                    Female2.GetComponent<Button>().interactable = false;
                    Female3.GetComponent<Button>().interactable = false;
                    staffPicked = true;
                }
                else
                {
                    Debug.Log("Male1 less than 0");
                }
                break;
            case "Male2N":
                if (Male2Amount > 0)
                {
                    Debug.Log(staffButtonClickedName + " clicked");
                    Male1.GetComponent<Button>().interactable = false;
                    Male3.GetComponent<Button>().interactable = false;
                    Female1.GetComponent<Button>().interactable = false;
                    Female2.GetComponent<Button>().interactable = false;
                    Female3.GetComponent<Button>().interactable = false;
                    staffPicked = true;
                }
                else
                {
                    Debug.Log("Male2 less than 0");
                }
                break;
            case "Male3N":
                if (Male3Amount > 0)
                {
                    Debug.Log(staffButtonClickedName + " clicked");
                    Male1.GetComponent<Button>().interactable = false;
                    Male2.GetComponent<Button>().interactable = false;
                    Female1.GetComponent<Button>().interactable = false;
                    Female2.GetComponent<Button>().interactable = false;
                    Female3.GetComponent<Button>().interactable = false;
                    staffPicked = true;
                }
                else
                {
                    Debug.Log("Male3 less than 0");
                }
                break;
            case "Female1N":
                if (Female1Amount > 0)
                {
                    Debug.Log(staffButtonClickedName + " clicked");
                    Male1.GetComponent<Button>().interactable = false;
                    Male2.GetComponent<Button>().interactable = false;
                    Male3.GetComponent<Button>().interactable = false;
                    Female2.GetComponent<Button>().interactable = false;
                    Female3.GetComponent<Button>().interactable = false;
                    staffPicked = true;
                }
                else
                {
                    Debug.Log("Female1 less than 0");
                }
                break;
            case "Female2N":
                if (Female2Amount > 0)
                {
                    Debug.Log(staffButtonClickedName + " clicked");
                    Male1.GetComponent<Button>().interactable = false;
                    Male2.GetComponent<Button>().interactable = false;
                    Male3.GetComponent<Button>().interactable = false;
                    Female1.GetComponent<Button>().interactable = false;
                    Female3.GetComponent<Button>().interactable = false;
                    staffPicked = true;
                }
                else
                {
                    Debug.Log("Female2 less than 0");
                }
                break;
            case "Female3N":
                if (Female3Amount > 0)
                {
                    Debug.Log(staffButtonClickedName + " clicked");
                    Male1.GetComponent<Button>().interactable = false;
                    Male2.GetComponent<Button>().interactable = false;
                    Male3.GetComponent<Button>().interactable = false;
                    Female1.GetComponent<Button>().interactable = false;
                    Female2.GetComponent<Button>().interactable = false;
                    staffPicked = true;
                }
                else
                {
                    Debug.Log("Female3 less than 0");
                }
                break;
        }
    }

    void CHooseStaffText()
    {
        if (staffPicked == true)
            chooseStaff.text = ("Staff OK!").ToString();
        chooseStaff.text = ("Choose Staff!").ToString();
    }
}
