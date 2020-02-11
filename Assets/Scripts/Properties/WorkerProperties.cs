//using System.Collections;
using UnityEngine;

public struct WorkerProperties
{
    private string _workerName;
    private double _earnings;
    public double _speedBonus;
    public double _happinessBonus;

    public string WorkerName
    {
        get
        {
            return _workerName;
        }

        set
        {
            _workerName = value;
        }
    }

    public double Earnings
    {
        get
        {
            return _earnings;
        }

        set
        {
            _earnings = value;
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