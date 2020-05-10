using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MakeTrain : MonoBehaviour
{
    public TrainProperties Train1;
    public TrainProperties Train2;
    public TrainProperties Train3;

    ////////////////////Train1////////////////////
    public TextMeshProUGUI train1Price;
    public TextMeshProUGUI train1SpeedBonus;
    public TextMeshProUGUI train1HappinessBonus;
    public TextMeshProUGUI train1Capacity;

    ////////////////////Train2////////////////////
    public TextMeshProUGUI train2Price;
    public TextMeshProUGUI train2SpeedBonus;
    public TextMeshProUGUI train2HappinessBonus;
    public TextMeshProUGUI train2Capacity;

    ////////////////////Train3////////////////////
    public TextMeshProUGUI train3Price;
    public TextMeshProUGUI train3SpeedBonus;
    public TextMeshProUGUI train3HappinessBonus;
    public TextMeshProUGUI train3Capacity;

    #region FakeSingleton
    public static MakeTrain instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        //////////////////////Trains//////////////////////

        Train1 = new TrainProperties()
        {
            TrainName = "Train1",
            Price = 1E5,
            SpeedBonus = 1.2,
            HappinessBonus = 1.1,
            Capacity = 500
        };

        Train2 = new TrainProperties()
        {
            TrainName = "Train2",
            Price = 3E4,
            SpeedBonus = 1.0,
            HappinessBonus = 1.0,
            Capacity = 400
        };

        Train3 = new TrainProperties()
        {
            TrainName = "Train3",
            Price = 1E4,
            SpeedBonus = 0.8,
            HappinessBonus = 0.8,
            Capacity = 350
        };

        ////////////////////Train1////////////////////
        train1Price.text = "Price: " + Train1.Price.ToString();
        train1SpeedBonus.text = "Speed Bonus: " + Train1.SpeedBonus.ToString();
        train1HappinessBonus.text = "Happiness Bonus: " + Train1.HappinessBonus.ToString();
        train1Capacity.text = "Capacity: " + Train1.Capacity.ToString();

        ////////////////////Train2////////////////////
        train2Price.text = "Price: " + Train2.Price.ToString();
        train2SpeedBonus.text = "Speed Bonus: " + Train2.SpeedBonus.ToString();
        train2HappinessBonus.text = "Happiness Bonus: " + Train2.HappinessBonus.ToString();
        train2Capacity.text = "Capacity: " + Train2.Capacity.ToString();

        ////////////////////Train3////////////////////
        train3Price.text = "Price: " + Train3.Price.ToString();
        train3SpeedBonus.text = "Speed Bonus: " + Train3.SpeedBonus.ToString();
        train3HappinessBonus.text = "Happiness Bonus: " + Train3.HappinessBonus.ToString();
        train3Capacity.text = "Capacity: " + Train3.Capacity.ToString();
    }
}
