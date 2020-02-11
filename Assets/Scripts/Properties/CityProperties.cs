//using System.Collections;
using UnityEngine;

public struct CityProperties
{
    private string _cityName;
    private double _citizens;
    public double _balancer;

    public string CityName
    {
        get
        {
            return _cityName;
        }

        set
        {
            _cityName = value;
        }
    }

    public double Citizens
    {
        get
        {
            return _citizens;
        }

        set
        {
            _citizens = value;
        }
    }

    public double Balancer
    {
        get
        {
            return _balancer;
        }

        set
        {
            _balancer = value;
        }
    }
}