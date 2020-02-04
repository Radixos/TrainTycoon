using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class TrainSystem : MonoBehaviour
{
    //TODO: Make something such as struct to hold parameters of each object

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

    private CityProperties TheCapitol;
    private CityProperties AlmostSnow;
    private CityProperties CloseToRussia;
    private CityProperties MountainCity;
    private CityProperties FaraonCity;

    private WorkerProperties Male1;
    private WorkerProperties Male2;
    private WorkerProperties Male3;
    private WorkerProperties Female1;
    private WorkerProperties Female2;
    private WorkerProperties Female3;

    private TrainProperties Train1;
    private TrainProperties Train2;
    private TrainProperties Train3;

    public TMP_Dropdown sendFromDropdown;
    public TMP_Dropdown destinationDropdown;

    private float timeOfTravel;
    public TextMeshProUGUI timeOfTravelText;

    public Slider ticketPriceSlider;

    //public GameObject TheCapitol;
    //public GameObject AlmostSnow;
    //public GameObject CloseToRussia;
    //public GameObject MountainCity;
    //public GameObject FaraonCity;

    //public GameObject Male1;
    //public GameObject Male2;
    //public GameObject Male3;
    //public GameObject Female1;
    //public GameObject Female2;
    //public GameObject Female3;

    //public GameObject Train1;
    //public GameObject Train2;
    //public GameObject Train3;

    private float moneyAmount = 50000f;
    public TMPro.TextMeshProUGUI MoneyAmountText;

    //void MakeCity(GameObject cityName, double citizens, double balancer)
    //{
    //    Debug.Log(cityName + " " + citizens + " " + balancer);
    //}

    //void MakeWorker(GameObject workerName, double earnings, double speedBonus, double happinessBonus)
    //{
    //    Debug.Log(workerName + " " + earnings + " " + speedBonus + " " + happinessBonus);
    //}

    //void MakeTrain(GameObject trainName, double price, double speedBonus, double happinessBonus)
    //{
    //    Debug.Log(trainName + " " + price + " " + speedBonus + " " + happinessBonus);
    //}

    void PassPrice()
    {
        //Debug.Log(ticketPriceSlider.value.ToString() /*ticketPriceSlider.onValueChanged.ToString()*/);
    }

    void MoneyUpdate()
    {
        MoneyAmountText.text = moneyAmount.ToString() + " £";

        //if (moneyAmount >= (0 + ))

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //Input.GetButtonDown
            moneyAmount -= 1000f;
        }
    }

    void Start()
    {
        //////////////////////Cities//////////////////////

        TheCapitol = new CityProperties
        {
            CityName = "TheCapitol",
            Citizens = 1E7,
            Balancer = 0.8
        };

        AlmostSnow = new CityProperties
        {
            CityName = "AlmostSnow",
            Citizens = 1E7,
            Balancer = 0.8
        };

        CloseToRussia = new CityProperties
        {
            CityName = "CloseToRussia",
            Citizens = 1E7,
            Balancer = 0.8
        };

        MountainCity = new CityProperties
        {
            CityName = "MountainCity",
            Citizens = 1E7,
            Balancer = 0.8
        };

        FaraonCity = new CityProperties
        {
            CityName = "FaraonCity",
            Citizens = 1E7,
            Balancer = 0.8
        };

        //////////////////////Workers//////////////////////

        Male1 = new WorkerProperties
        {
            WorkerName = "Male1",
            Earnings = 5E3,
            SpeedBonus = 1.2,
            HappinessBonus = 1.1
        };

        Male2 = new WorkerProperties
        {
            WorkerName = "Male2",
            Earnings = 35E2,
            SpeedBonus = 1,
            HappinessBonus = 0.9
        };

        Male3 = new WorkerProperties
        {
            WorkerName = "Male3",
            Earnings = 15E2,
            SpeedBonus = 0.8,
            HappinessBonus = 0.7
        };

        Female1 = new WorkerProperties
        {
            WorkerName = "Female1",
            Earnings = 5E3,
            SpeedBonus = 1.1,
            HappinessBonus = 1.2
        };

        Female2 = new WorkerProperties
        {
            WorkerName = "Female2",
            Earnings = 35E2,
            SpeedBonus = 0.9,
            HappinessBonus = 1
        };

        Female3 = new WorkerProperties
        {
            WorkerName = "Female3",
            Earnings = 15E2,
            SpeedBonus = 0.7,
            HappinessBonus = 0.8
        };

        //////////////////////Trains//////////////////////

        Train1 = new TrainProperties
        {
            TrainName = "Train1",
            Price = 1E5,
            SpeedBonus = 1.2,
            HappinessBonus = 1.1
        };

        Train2 = new TrainProperties
        {
            TrainName = "Train2",
            Price = 3E4,
            SpeedBonus = 1.0,
            HappinessBonus = 1.0
        };

        Train3 = new TrainProperties
        {
            TrainName = "Train3",
            Price = 1E4,
            SpeedBonus = 0.8,
            HappinessBonus = 0.8
        };

        //foreach (var s in citySerializes)
        //{
        //    Tuple</*GameObject, */double, double> cityParameters = new Tuple</*GameObject, */double, double>(/*s.cityName, */s.citizens, s.balancer);
        //    cityDictionary.Add(s.value, cityParameters);
        //    //Debug.Log(s.cityName);
        //}

        //foreach (var s in workerSerializes)
        //{
        //    Tuple<GameObject, double, double, double> workerParameters = new Tuple<GameObject, double, double, double>(s.worker, s.earnings, s.speedBonus, s.happinessBonus);
        //    workerDictionary.Add(s.value, workerParameters);
        //    Debug.Log(s.worker);
        //}

        //foreach (var s in trainSerializes)
        //{
        //    Tuple<GameObject, double, double, double> trainParameters = new Tuple<GameObject, double, double, double>(s.train, s.price, s.speedBonus, s.happinessBonus);
        //    trainDictionary.Add(s.value, trainParameters);
        //    Debug.Log(s.train);
        //}

        //MakeCity(TheCapitol, 1E7, 0.8);  //10 000 000   add (float)1E7...??
        //MakeCity(AlmostSnow, 5E5, 1.3);  //500 000
        //MakeCity(CloseToRussia, 3E6, 1.05); //3 000 000
        //MakeCity(MountainCity, 222E4, 1.1); //2 220 000
        //MakeCity(FaraonCity, 735E3, 1.2);   //735 000

        //MakeWorker(Male1, 5E3, 1.2, 1.1);   //5 000     Solve double problem - should be int -> can be 5000 but not 5E3
        //MakeWorker(Male2, 35E2, 1, 0.9);    //3 500
        //MakeWorker(Male3, 15E2, 0.8, 0.7);  //1 500
        //MakeWorker(Female1, 5E3, 1.1, 1.2); //5 000
        //MakeWorker(Female2, 35E2, 0.9, 1);  //3 500
        //MakeWorker(Female3, 15E2, 0.7, 0.8);//1 500

        //MakeTrain(Train1, 1E5, 1.2, 1.1);   //100 000
        //MakeTrain(Train2, 3E4, 1.0, 1.0);   //30 000
        //MakeTrain(Train3, 1E4, 0.8, 0.8);   //10 000

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
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 3)
        {
            timeOfTravel = 6f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 4)
        {
            timeOfTravel = 3f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 1 & destinationDropdown.value == 5)
        {
            timeOfTravel = 4f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 1)
        {
            timeOfTravel = 5f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 3)
        {
            timeOfTravel = 2f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 4)
        {
            timeOfTravel = 8f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 2 & destinationDropdown.value == 5)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 1)
        {
            timeOfTravel = 6f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 2)
        {
            timeOfTravel = 2f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 4)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 3 & destinationDropdown.value == 5)
        {
            timeOfTravel = 10f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 1)
        {
            timeOfTravel = 3f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 2)
        {
            timeOfTravel = 8f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 3)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 4 & destinationDropdown.value == 5)
        {
            timeOfTravel = 7f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 1)
        {
            timeOfTravel = 4f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 2)
        {
            timeOfTravel = 9f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 3)
        {
            timeOfTravel = 10f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }

        if (sendFromDropdown.value == 5 & destinationDropdown.value == 4)
        {
            timeOfTravel = 7f;
            timeOfTravelText.text = "Time of Travel:\n" + timeOfTravel.ToString() + "h";
        }
    }
}
