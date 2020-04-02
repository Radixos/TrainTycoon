using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrainPick : MonoBehaviour
{
    public GameObject currentGO;

    public GameObject Train1;
    public GameObject Train2;
    public GameObject Train3;

    public GameObject Train1Original;
    public GameObject Train2Original;
    public GameObject Train3Original;

    private int Train1Amount;
    private int Train2Amount;
    private int Train3Amount;

    private bool trainPicked = false;

    public TextMeshProUGUI chooseTrain;

    private string trainButtonClickedName;

    private void Start()
    {
        InvokeRepeating("UpdateTrainAssets", 0f, 1f);
    }

    private void Update()
    {
        TrainOK();
    }

    void UpdateTrainAssets()
    {
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

    public void TrainPickFunction()
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

    void TrainOK()
    {
        if (trainPicked == true)
            chooseTrain.text = ("Train OK!").ToString();
        chooseTrain.text = ("Choose Train!").ToString();
    }
}
