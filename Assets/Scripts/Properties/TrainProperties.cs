using System.Collections;
using UnityEngine;

public class TrainProperties : MonoBehaviour
{
    private string _trainName;
    private double _price;
    public double _speedBonus;
    public double _happinessBonus;

    public string TrainName
    {
        get
        {
            return _trainName;
        }

        set
        {
            _trainName = value;
        }
    }

    public double Price
    {
        get
        {
            return _price;
        }

        set
        {
            _price = value;
        }
    }

    public double SpeedBonus
    {
        get
        {
            return _speedBonus;
        }

        set
        {
            _speedBonus = value;
        }
    }

    public double HappinessBonus
    {
        get
        {
            return _happinessBonus;
        }

        set
        {
            _happinessBonus = value;
        }
    }
}