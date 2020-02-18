using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

//TODO: make text fields above tracks/cities appear with ETA time
//TODO: make number of citizens decrease in starting city on "dispatch train" button press and increase in destination city on arrival
//TODO: Make number of citizens willing to travel update only after dispatching train from chosen city, otherwise stay the same untill dispatched
//TODO: Tie number of assets and dispatching trains together
//TODO: Optimize earnings via adding expenses such as insurances, taxes, fuel, etc
//TODO: Make additional panel pop up on clicking dispatch train to select what train and what worker to use
//TODO: Fix camera so after it rotates it moves in local left, right, forward and backward insted of world directios

public class TrainSystem : MonoBehaviour
{
    //[System.Serializable]
    //public class SerializeCity
    //{
    //    public string value;
    //    //public GameObject cityName;
    //    public double citizens;
    //    public double balancer;
    //}

    //public Dictionary<string, Tuple</*GameObject, */double, double>> cityDictionary = new Dictionary<string, Tuple</*GameObject, */double, double>>();
    //public List<SerializeCity> citySerializes = new List<SerializeCity>();

    //[System.Serializable]
    //public class SerializeWorker
    //{
    //    public string value;
    //    public GameObject worker;
    //    public double earnings;
    //    public double speedBonus;
    //    public double happinessBonus;
    //}

    //public Dictionary<string, Tuple<GameObject, double, double, double>> workerDictionary = new Dictionary<string, Tuple<GameObject, double, double, double>>();
    //public List<SerializeWorker> workerSerializes = new List<SerializeWorker>();

    //[System.Serializable]
    //public class SerializeTrains
    //{
    //    public string value;
    //    public GameObject train;
    //    public double price;
    //    public double speedBonus;
    //    public double happinessBonus;
    //}

    //public Dictionary<string, Tuple<GameObject, double, double, double>> trainDictionary = new Dictionary<string, Tuple<GameObject, double, double, double>>();
    //public List<SerializeTrains> trainSerializes = new List<SerializeTrains>();

    public TMP_Dropdown sendFromDropdown;
    public TMP_Dropdown destinationDropdown;

    public float timeOfTravel;
    public TextMeshProUGUI timeOfTravelText;

    public Slider ticketPriceSlider;

    private double moneyAmount = 50000f;
    public TMPro.TextMeshProUGUI MoneyAmountText;

    MakeWorker HireWorkerScript;

    private void DispatchTrain()
    {

    }

    void PassPrice()
    {
        //Debug.Log(ticketPriceSlider.value.ToString() /*ticketPriceSlider.onValueChanged.ToString()*/);
    }

    void MoneyUpdate()
    {
        //MoneyAmountText.text = moneyAmount.ToString() + " £";

        //if (moneyAmount >= (0 + ))

        //if (HireWorkerScript.Male1)
        //{
        //    //Input.GetButtonDown
        //    moneyAmount -= HireWorkerScript.Female1.Earnings;
        //}
    }

    void Start()
    {
        HireWorkerScript = GetComponentInParent<MakeWorker>();

        sendFromDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(sendFromDropdown); });

        //timeOfTravelText.text = "First Value: " + sendFromDropdown.value;

        destinationDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(destinationDropdown); });

        //timeOfTravelText.text = "First Value: " + destinationDropdown.value;
    }

    private void Update()
    {
        PassPrice();
        MoneyUpdate();
    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        //timeOfTravelText.text = "Wrong destination" + change.value;

        if (sendFromDropdown.value == 0 || destinationDropdown.value == 0)
        {
            timeOfTravelText.text = "Wrong destination";
            return;
        }

        int firstValue = sendFromDropdown.value;
        int secondValue = destinationDropdown.value;
        int actualValue = secondValue - firstValue;

        if(actualValue == 0)
        {
            timeOfTravelText.text = "Wrong destination";
            return;
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 0)
        {
            timeOfTravelText.text = "Wrong destination";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 1)
        {
            timeOfTravelText.text = "Wrong destination";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 2)
        {
            timeOfTravel = 5f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 3)
        {
            timeOfTravel = 6f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 4)
        {
            timeOfTravel = 3f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 5)
        {
            timeOfTravel = 4f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 1)
        {
            timeOfTravel = 5f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 3)
        {
            timeOfTravel = 2f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 4)
        {
            timeOfTravel = 8f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 5)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 1)
        {
            timeOfTravel = 6f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 2)
        {
            timeOfTravel = 2f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 4)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 5)
        {
            timeOfTravel = 10f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 1)
        {
            timeOfTravel = 3f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 2)
        {
            timeOfTravel = 8f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 3)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 5)
        {
            timeOfTravel = 7f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 1)
        {
            timeOfTravel = 4f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 2)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 3)
        {
            timeOfTravel = 10f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 4)
        {
            timeOfTravel = 7f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + " h";
        }
    }
}
