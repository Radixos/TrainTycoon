using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeCity : MonoBehaviour
{
    private CityProperties TheCapitol;
    private CityProperties AlmostSnow;
    private CityProperties CloseToRussia;
    private CityProperties MountainCity;
    private CityProperties FaraonCity;

    public TextMeshPro theCapitolCitizens;
    public TextMeshPro almostSnowCitizens;
    public TextMeshPro closeToRussiaCitizens;
    public TextMeshPro mountainCityCitizens;
    public TextMeshPro faraonCityCitizens;

    private int numberOfPassengers;
    private float passengerNumberVariation;
    private int tempNumberOfCitizens;
    public int numberOfPassengersBalancer;

    MakeCity MakeCityScript;
    TrainSystem TrainSystemScript;

    private int CalculateNumberOfPassengers()
    {
        passengerNumberVariation = UnityEngine.Random.Range(0f, 0.2f) * 100;

        //Debug.Log((int)passengerNumberVariation);

        switch (TrainSystemScript.sendFromDropdown.value)
        {
            case 1:
                if (TheCapitol.Citizens > 1E7 / 50)     //Assuming every 50th person wants to travel
                    tempNumberOfCitizens = (int)TheCapitol.Citizens;

                Debug.Log("There are no passengers willing to travel from The Capitol.");
                break;
            case 2:
                if (AlmostSnow.Citizens > 5E5 / 50)
                    tempNumberOfCitizens = (int)AlmostSnow.Citizens;

                Debug.Log("There are no passengers willing to travel from Almost Snow.");
                break;
            case 3:
                if (CloseToRussia.Citizens > 3E6 / 50)
                    tempNumberOfCitizens = (int)CloseToRussia.Citizens;

                Debug.Log("There are no passengers willing to travel from Close To Russia.");
                break;
            case 4:
                if (MountainCity.Citizens > 222E4 / 50)
                    tempNumberOfCitizens = (int)MountainCity.Citizens;

                Debug.Log("There are no passengers willing to travel from Mountain City.");
                break;
            case 5:
                if (FaraonCity.Citizens > 735E3 / 50)
                    tempNumberOfCitizens = (int)FaraonCity.Citizens;

                Debug.Log("There are no passengers willing to travel from Faraon City.");
                break;
        }
        numberOfPassengers = ((int)passengerNumberVariation * tempNumberOfCitizens) / numberOfPassengersBalancer;
        //Debug.Log(numberOfPassengers);
        return numberOfPassengers;
    }

    void Start()
    {
        MakeCityScript = GetComponentInParent<MakeCity>();
        TrainSystemScript = GetComponentInParent<TrainSystem>();

        //////////////////////Cities//////////////////////

        TheCapitol = new CityProperties()
        {
            CityName = "TheCapitol",
            Citizens = 1E7,
            Balancer = 0.8
        };

        AlmostSnow = new CityProperties()
        {
            CityName = "AlmostSnow",
            Citizens = 5E5,
            Balancer = 1.3
        };

        CloseToRussia = new CityProperties()
        {
            CityName = "CloseToRussia",
            Citizens = 3E6,
            Balancer = 1.05
        };

        MountainCity = new CityProperties()
        {
            CityName = "MountainCity",
            Citizens = 222E4,
            Balancer = 1.1
        };

        FaraonCity = new CityProperties()
        {
            CityName = "FaraonCity",
            Citizens = 735E3,
            Balancer = 1.2
        };

        theCapitolCitizens.text = "Citizens: " + TheCapitol.Citizens.ToString();
        almostSnowCitizens.text = "Citizens: " + AlmostSnow.Citizens.ToString();
        closeToRussiaCitizens.text = "Citizens: " + CloseToRussia.Citizens.ToString();
        mountainCityCitizens.text = "Citizens: " + MountainCity.Citizens.ToString();
        faraonCityCitizens.text = "Citizens: " + FaraonCity.Citizens.ToString();
    }

    void Update()
    {
        CalculateNumberOfPassengers();
    }
}
