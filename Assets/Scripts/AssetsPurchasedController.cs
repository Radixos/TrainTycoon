using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: To finish this class after implementing dispatch train panel

public class AssetsPurchasedController : MonoBehaviour
{
    public Button ConfirmButton;

    [HideInInspector] public bool confirmed = false;
    public string trainType;
    public string staffType;
    [HideInInspector] public int staffEarnings = 0;
    [HideInInspector] public int iETA;
    [HideInInspector] public bool trainDispatched = false;

    public GameObject sendFrom;
    public GameObject sendTo;

    public GameObject confirmPanel;

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

    private bool staffPickedBool = false;
    private bool trainPickedBool = false;

    [SerializeField] private TextMeshProUGUI departureCityTemplate;
    [SerializeField] private TextMeshProUGUI destinationCityTemplate;
    [SerializeField] private TextMeshProUGUI trainPickedTemplate;
    [SerializeField] private TextMeshProUGUI staffPickedTemplate;
    [SerializeField] private TextMeshProUGUI ETATemplate;

    //private int[] intArray;
    //private int intArrayCounter = 0;

    public TextMeshProUGUI chooseStaff;
    public TextMeshProUGUI chooseTrain;

    public TMP_ColorGradient green;
    public TMP_ColorGradient red;

    #region FakeSingleton
    public static AssetsPurchasedController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

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

    void UpdateAssetsReverse()
    {
        if (Male1.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male1Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Male1.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Male2.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male2Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Male2.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Male3.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male3Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Male3.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if (Female1.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Female1Original.GetComponentInChildren<TextMeshProUGUI>().text = Female1.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Female2.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Female2Original.GetComponentInChildren<TextMeshProUGUI>().text = Female2.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Female3.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Female3Original.GetComponentInChildren<TextMeshProUGUI>().text = Female3.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Train1.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Train1Original.GetComponentInChildren<TextMeshProUGUI>().text = Train1.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Train2.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Train2Original.GetComponentInChildren<TextMeshProUGUI>().text = Train2.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Train3.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Train3Original.GetComponentInChildren<TextMeshProUGUI>().text = Train3.GetComponentInChildren<TextMeshProUGUI>().text;
        }
    }

    public void Male1Pick()
    {
        if (Male1Amount > 0)
        {
            Debug.Log("Male1 clicked");
            Male1.GetComponent<Button>().interactable = false;
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPickedBool = true;
            staffType = "Male1";
            staffEarnings = (int)MakeWorker.instance.Male1.Earnings;
            Male1Amount--;
            Male1Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Male1Amount.ToString());
        }
        else
        {
            Debug.Log("Male1 less than 0");
        }
    }

    public void Male2Pick()
    {
        if (Male2Amount > 0)
        {
            Debug.Log("Male2 clicked");
            Male1.GetComponent<Button>().interactable = false;
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPickedBool = true;
            staffType = "Male2";
            staffEarnings = (int)MakeWorker.instance.Male2.Earnings;
            Male2Amount--;
            Male2Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Male2Amount.ToString());
        }
        else
        {
            Debug.Log("Male2 less than 0");
        }
    }

    public void Male3Pick()
    {
        if (Male3Amount > 0)
        {
            Debug.Log("Male3 clicked");
            Male1.GetComponent<Button>().interactable = false;
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPickedBool = true;
            staffType = "Male3";
            staffEarnings = (int)MakeWorker.instance.Male3.Earnings;
            Male3Amount--;
            Male3Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Male3Amount.ToString());
        }
        else
        {
            Debug.Log("Male3 less than 0");
        }
    }

    public void Female1Pick()
    {
        if (Female1Amount > 0)
        {
            Debug.Log("Female1 clicked");
            Male1.GetComponent<Button>().interactable = false;
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPickedBool = true;
            staffType = "Female1";
            staffEarnings = (int)MakeWorker.instance.Female1.Earnings;
            Female1Amount--;
            Female1Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Female1Amount.ToString());
        }
        else
        {
            Debug.Log("Female1 less than 0");
        }
    }

    public void Female2Pick()
    {
        if (Female2Amount > 0)
        {
            Debug.Log("Female2 clicked");
            Male1.GetComponent<Button>().interactable = false;
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPickedBool = true;
            staffType = "Female2";
            staffEarnings = (int)MakeWorker.instance.Female2.Earnings;
            Female2Amount--;
            Female2Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Female2Amount.ToString());
        }
        else
        {
            Debug.Log("Female2 less than 0");
        }
    }

    public void Female3Pick()
    {
        if (Female3Amount > 0)
        {
            Debug.Log("Female3 clicked");
            Male1.GetComponent<Button>().interactable = false;
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPickedBool = true;
            staffType = "Female3";
            staffEarnings = (int)MakeWorker.instance.Female3.Earnings;
            Female3Amount--;
            Female3Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Female3Amount.ToString());
        }
        else
        {
            Debug.Log("Female3 less than 0");
        }
    }

    public void Train1Pick()
    {
        if (Train1Amount > 0)
        {
            Debug.Log("Train1 clicked");
            Train1.GetComponent<Button>().interactable = false;
            Train2.GetComponent<Button>().interactable = false;
            Train3.GetComponent<Button>().interactable = false;
            trainPickedBool = true;
            trainType = "Train1";
            Train1Amount--;
            Train1Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Train1Amount.ToString());
        }
        else
        {
            Debug.Log("Train1 less than 0");
        }
    }
    public void Train2Pick()
    {
        if (Train2Amount > 0)
        {
            Debug.Log("Train2 clicked");
            Train1.GetComponent<Button>().interactable = false;
            Train2.GetComponent<Button>().interactable = false;
            Train3.GetComponent<Button>().interactable = false;
            trainPickedBool = true;
            trainType = "Train2";
            Train2Amount--;
            Train2Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Train2Amount.ToString());
        }
        else
        {
            Debug.Log("Train2 less than 0");
        }
    }
    public void Train3Pick()
    {
        if (Train3Amount > 0)
        {
            Debug.Log("Train3 clicked");
            Train1.GetComponent<Button>().interactable = false;
            Train2.GetComponent<Button>().interactable = false;
            Train3.GetComponent<Button>().interactable = false;
            trainPickedBool = true;
            trainType = "Train3";
            Train3Amount--;
            Train3Original.GetComponentInChildren<TextMeshProUGUI>().SetText(Train3Amount.ToString());
        }
        else
        {
            Debug.Log("Train3 less than 0");
        }
    }

    public void ConfirmButtonAction()
    {
        //System.Timers.Timer countdownTimer;
        //countdownTimer = new System.Timers.Timer(1000);
        //countdownTimer. += OnTimer_Tick;

        TextMeshProUGUI departureCity = Instantiate(departureCityTemplate) as TextMeshProUGUI;
        departureCity.gameObject.SetActive(true);
        departureCity.SetText(sendFrom.GetComponentInChildren<TMP_Dropdown>().options[sendFrom.GetComponentInChildren<TMP_Dropdown>().value].text);
        departureCity.transform.SetParent(departureCityTemplate.transform.parent, false);

        TextMeshProUGUI destinationCity = Instantiate(destinationCityTemplate) as TextMeshProUGUI;
        destinationCity.gameObject.SetActive(true);
        destinationCity.SetText(sendTo.GetComponentInChildren<TMP_Dropdown>().options[sendTo.GetComponentInChildren<TMP_Dropdown>().value].text);
        destinationCity.transform.SetParent(destinationCityTemplate.transform.parent, false);

        TextMeshProUGUI trainPicked = Instantiate(trainPickedTemplate) as TextMeshProUGUI;
        trainPicked.gameObject.SetActive(true);
        trainPicked.SetText(trainType);
        trainPicked.transform.SetParent(trainPickedTemplate.transform.parent, false);

        TextMeshProUGUI staffPicked = Instantiate(staffPickedTemplate) as TextMeshProUGUI;
        staffPicked.gameObject.SetActive(true);
        staffPicked.SetText(staffType);
        staffPicked.transform.SetParent(staffPickedTemplate.transform.parent, false);

        TextMeshProUGUI ETA = Instantiate(ETATemplate) as TextMeshProUGUI;
        ETA.gameObject.SetActive(true);
        ETA.SetText(TrainSystem.instance.timeOfTravel.ToString());
        ETA.transform.SetParent(ETATemplate.transform.parent, false);

        UpdateAssets(); //Is it needed here?

        int iETA = int.Parse(ETA.text);
        //Debug.Log(iETA);
        trainDispatched = true;
        Debug.Log("Train dispatched: " + trainDispatched);
        //LevelManager.instance.CalculateEarnings(iETA);

        Destroy(departureCity, iETA);
        Destroy(destinationCity, iETA);
        Destroy(trainPicked, iETA);
        Destroy(staffPicked, iETA);
        Destroy(ETA, iETA);

        /*
        int* newArray = new int[newSize];
        ... copying from old array ...
        int* temp = oldArray;
        oldArray = newArray;
        delete[] temp;
        */

        //intArrayCounter++;
        //int[] newArray = new int[intArrayCounter];
        //int[] temp = intArray;
        //intArray = newArray;
        //Can not delete temp array in C#, how to clean it? Should I?

        trainType = "None";
        staffType = "None";
        staffPickedBool = false;
        trainPickedBool = false;
        ConfirmButton.interactable = false;

        Male1.GetComponent<Button>().interactable = true;
        Male2.GetComponent<Button>().interactable = true;
        Male3.GetComponent<Button>().interactable = true;
        Female1.GetComponent<Button>().interactable = true;
        Female2.GetComponent<Button>().interactable = true;
        Female3.GetComponent<Button>().interactable = true;
        Train1.GetComponent<Button>().interactable = true;
        Train2.GetComponent<Button>().interactable = true;
        Train3.GetComponent<Button>().interactable = true;

        //confirmPanel.SetActive(false);
    }

    void ChooseStaffText(bool staffPicked)
    {
        if (staffPicked == true)
        {
            chooseStaff.SetText("Staff OK!");
            chooseStaff.colorGradientPreset = green;
            //Debug.Log("ChooseStaffText updated " + chooseStaff.text);
        }
        else
        {
            chooseStaff.SetText("Choose Staff!");
            chooseStaff.colorGradientPreset = red;
        }
    }

    void ChooseTrainText(bool trainPicked)
    {
        if (trainPicked == true)
        {
            chooseTrain.SetText("Train OK!");
            chooseTrain.colorGradientPreset = green;
            //Debug.Log("ChooseTrainText updated " + chooseTrain.text);
        }
        else
        {
            chooseTrain.SetText("Choose Train!");
            chooseTrain.colorGradientPreset = red;
        }
    }

    private void Start()
    {
        //InvokeRepeating("UpdateAssets", 0f, 1f);
        //InvokeRepeating("UpdateAssetsReverse", 0.5f, 1f);

        Male1.GetComponent<Button>().onClick.AddListener(Male1Pick);
        Male2.GetComponent<Button>().onClick.AddListener(Male2Pick);
        Male3.GetComponent<Button>().onClick.AddListener(Male3Pick);
        Female1.GetComponent<Button>().onClick.AddListener(Female1Pick);
        Female2.GetComponent<Button>().onClick.AddListener(Female2Pick);
        Female3.GetComponent<Button>().onClick.AddListener(Female3Pick);

        Train1.GetComponent<Button>().onClick.AddListener(Train1Pick);
        Train2.GetComponent<Button>().onClick.AddListener(Train2Pick);
        Train3.GetComponent<Button>().onClick.AddListener(Train3Pick);

        ConfirmButton.interactable = false;

        ConfirmButton.onClick.AddListener(ConfirmButtonAction);
    }

    void Update()
    {
        UpdateAssets();
        UpdateAssetsReverse();

        ChooseStaffText(staffPickedBool);
        ChooseTrainText(trainPickedBool);

        if (staffPickedBool && trainPickedBool)
        {
            ConfirmButton.interactable = true;
        }

        if (trainDispatched == true)
        {
            StartCoroutine(LevelManager.instance.CalculateEarnings(iETA));    //"" allows to stop coroutine
            trainDispatched = false;
            Debug.Log("Train dispatched: " + trainDispatched);
        }
    }
}
