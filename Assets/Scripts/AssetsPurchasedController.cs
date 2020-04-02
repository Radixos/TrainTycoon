using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: To finish this class after implementing dispatch train panel

public class AssetsPurchasedController : MonoBehaviour
{
    public Button ConfirmButton;

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

    private bool staffPicked = false;
    private bool trainPicked = false;

    public TextMeshProUGUI chooseStaff;
    public TextMeshProUGUI chooseTrain;

    public TMP_ColorGradient green;
    public TMP_ColorGradient red;

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
            Male1Original.GetComponentInChildren<TextMeshProUGUI>().text = Male1.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Male2.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male2Original.GetComponentInChildren<TextMeshProUGUI>().text = Male2.GetComponentInChildren<TextMeshProUGUI>().text;
        }
        if (Male3.GetComponentInChildren<TextMeshProUGUI>().text != "XX")
        {
            Male3Original.GetComponentInChildren<TextMeshProUGUI>().text = Male3.GetComponentInChildren<TextMeshProUGUI>().text;
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
            Male2.GetComponent<Button>().interactable = false;
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPicked = true;
            Male1Amount--;
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
            Male3.GetComponent<Button>().interactable = false;
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPicked = true;
            Male2Amount--;
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
            Female1.GetComponent<Button>().interactable = false;
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPicked = true;
            Male3Amount--;
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
            Female2.GetComponent<Button>().interactable = false;
            Female3.GetComponent<Button>().interactable = false;
            staffPicked = true;
            Female1Amount--;
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
            Female3.GetComponent<Button>().interactable = false;
            staffPicked = true;
            Female2Amount--;
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
            staffPicked = true;
            Female3Amount--;
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
            Train2.GetComponent<Button>().interactable = false;
            Train3.GetComponent<Button>().interactable = false;
            trainPicked = true;
            Train1Amount--;
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
            Train3.GetComponent<Button>().interactable = false;
            trainPicked = true;
            Train2Amount--;
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
            trainPicked = true;
            Train3Amount--;
        }
        else
        {
            Debug.Log("Train3 less than 0");
        }
    }

    void ChooseStaffText()
    {
        chooseStaff.SetText("Staff OK!");
        chooseStaff.colorGradientPreset = green;
        Debug.Log("ChooseStaffText updated " + chooseStaff.text);
    }

    void ChooseTrainText()
    {
        chooseTrain.SetText("Train OK!");
        chooseTrain.colorGradientPreset = green;
        Debug.Log("ChooseTrainText updated " + chooseTrain.text);
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
    }

    void Update()
    {
        UpdateAssets();
        UpdateAssetsReverse();


        if (staffPicked == true)    //Can't put it in a function. WHY
        {
            ChooseStaffText();
        }
        else
        {
            chooseStaff.SetText("Choose Staff!");
            chooseStaff.colorGradientPreset = red;
        }

        if (trainPicked == true)    //Can't put it in a function. WHY
        {
            ChooseTrainText();
        }
        else
        {
            chooseTrain.SetText("Choose Train!");
            chooseTrain.colorGradientPreset = red;
        }
    }
}
