using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//TODO: Fix StaffPick and TrainPick functions - as a reminder see console
//TODO: Fix ChangeGradient functions

public class AssetClicked : MonoBehaviour
{
    public GameObject currentGO;

    public GameObject Male1;
    public GameObject Male2;
    public GameObject Male3;
    public GameObject Female1;
    public GameObject Female2;
    public GameObject Female3;
    public GameObject Train1;
    public GameObject Train2;
    public GameObject Train3;

    public GameObject Male1Original;
    public GameObject Male2Original;
    public GameObject Male3Original;
    public GameObject Female1Original;
    public GameObject Female2Original;
    public GameObject Female3Original;
    public GameObject Train1Original;
    public GameObject Train2Original;
    public GameObject Train3Original;

    private int Male1Amount;
    private int Male2Amount;
    private int Male3Amount;
    private int Female1Amount;
    private int Female2Amount;
    private int Female3Amount;
    private int Train1Amount;
    private int Train2Amount;
    private int Train3Amount;

    private Button staffButton;
    private Button trainButton;

    private bool staffPicked = false;
    private bool trainPicked = false;

    public TMP_ColorGradient green;
    public TMP_ColorGradient red;

    public TextMeshProUGUI chooseTrain;
    public TextMeshProUGUI chooseStaff;

    private string staffButtonClickedName;
    private string trainButtonClickedName;

    void Start()
    {
        InvokeRepeating("UpdateAssets", 0f, 1f);

        //staffButton = Male1.GetComponent<Button>();
        //staffButton.onClick.AddListener(StaffPick);

        //staffButton = Male2.GetComponent<Button>();
        //staffButton.onClick.AddListener(StaffPick);

        //staffButton = Male3.GetComponent<Button>();
        //staffButton.onClick.AddListener(StaffPick);

        //staffButton = Female1.GetComponent<Button>();
        //staffButton.onClick.AddListener(StaffPick);

        //staffButton = Female2.GetComponent<Button>();
        //staffButton.onClick.AddListener(StaffPick);

        //staffButton = Female3.GetComponent<Button>();
        //staffButton.onClick.AddListener(StaffPick);

        //trainButton = Train1.GetComponent<Button>();
        //trainButton.onClick.AddListener(TrainPick);

        //trainButton = Train2.GetComponent<Button>();
        //trainButton.onClick.AddListener(TrainPick);

        //trainButton = Train3.GetComponent<Button>();
        //trainButton.onClick.AddListener(TrainPick);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChooseStaffGradient();
        ChangeChooseTrainGradient();
        //StaffPick();
        //TrainPick();
        //UpdateAssets();
    }

    void UpdateAssets()
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
        if (Train1Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Train1.GetComponentInChildren<TextMeshProUGUI>().text = Train1Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Train1Amount = int.Parse(Train1.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Train2Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Train2.GetComponentInChildren<TextMeshProUGUI>().text = Train2Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Train2Amount = int.Parse(Train2.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Train3Original.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Train3.GetComponentInChildren<TextMeshProUGUI>().text = Train3Original.GetComponentInChildren<TextMeshProUGUI>().text;
            Train3Amount = int.Parse(Train3.GetComponentInChildren<TextMeshProUGUI>().text);
        }
    }

    public void StaffPick()    //TODO: fix this function and one below
    {
        //staffButtonClickedName = staffButton.name;
        staffButtonClickedName = currentGO.name;

        //Debug.Log(staffButtonClickedName);

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

    public void TrainPick()
    {
        //trainButtonClickedName = trainButton.name;
        trainButtonClickedName = currentGO.name;

        //Debug.Log(trainButtonClickedName);

        switch (trainButtonClickedName)
        {
            case "Train1N":
                if (Train1Amount > 0)
                {
                    Debug.Log(trainButtonClickedName + " clicked");
                    Train2.GetComponent<Button>().interactable = false;
                    Train3.GetComponent<Button>().interactable = false;
                    trainPicked = true;
                }
                else
                {
                    Debug.Log("Train1 less than 0");
                }
                break;
            case "Train2N":
                if (Train2Amount > 0)
                {
                    Debug.Log(trainButtonClickedName + " clicked");
                    Train1.GetComponent<Button>().interactable = false;
                    Train3.GetComponent<Button>().interactable = false;
                    trainPicked = true;
                }
                else
                {
                    Debug.Log("Train2 less than 0");
                }
                break;
            case "Train3N":
                if (Train3Amount > 0)
                {
                    Debug.Log(trainButtonClickedName + " clicked");
                    Train1.GetComponent<Button>().interactable = false;
                    Train2.GetComponent<Button>().interactable = false;
                    trainPicked = true;
                }
                else
                {
                    Debug.Log("Train3 less than 0");
                }
                break;
        }
    }

    public void ChangeChooseStaffGradient()
    {
        if (staffPicked == true)
            chooseStaff.GetComponent<TextMeshProUGUI>().colorGradientPreset.Equals(green);
        chooseStaff.GetComponent<TextMeshProUGUI>().colorGradientPreset.Equals(red);
    }

    public void ChangeChooseTrainGradient()
    {
        if (trainPicked == true)
            chooseTrain.GetComponent<TextMeshProUGUI>().colorGradientPreset.Equals(green);
        chooseTrain.GetComponent<TextMeshProUGUI>().colorGradientPreset.Equals(red);
    }
}