using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HireWorker : MonoBehaviour
{
    //public GameObject Male1Obj;
    //public GameObject Male2Obj;
    //public GameObject Male3Obj;
    //public GameObject Female1Obj;
    //public GameObject Female2Obj;
    //public GameObject Female3Obj;

    public WorkerProperties Male1;
    public WorkerProperties Male2;
    public WorkerProperties Male3;
    public WorkerProperties Female1;
    public WorkerProperties Female2;
    public WorkerProperties Female3;

    ////////////////////Male1////////////////////
    public TextMeshProUGUI male1Earnings;
    public TextMeshProUGUI male1SpeedBonus;
    public TextMeshProUGUI male1HappinessBonus;

    ////////////////////Male2////////////////////
    public TextMeshProUGUI male2Earnings;
    public TextMeshProUGUI male2SpeedBonus;
    public TextMeshProUGUI male2HappinessBonus;

    ////////////////////Male3////////////////////
    public TextMeshProUGUI male3Earnings;
    public TextMeshProUGUI male3SpeedBonus;
    public TextMeshProUGUI male3HappinessBonus;

    ////////////////////Female1////////////////////
    public TextMeshProUGUI female1Earnings;
    public TextMeshProUGUI female1SpeedBonus;
    public TextMeshProUGUI female1HappinessBonus;

    ////////////////////Female2////////////////////
    public TextMeshProUGUI female2Earnings;
    public TextMeshProUGUI female2SpeedBonus;
    public TextMeshProUGUI female2HappinessBonus;

    ////////////////////Female3////////////////////
    public TextMeshProUGUI female3Earnings;
    public TextMeshProUGUI female3SpeedBonus;
    public TextMeshProUGUI female3HappinessBonus;

    void Start()
    {
        //////////////////////Workers//////////////////////

        Male1 = new WorkerProperties()
        {
            WorkerName = "Male1",
            Earnings = 5E3,
            SpeedBonus = 1.2,
            HappinessBonus = 1.1
        };

        Male2 = new WorkerProperties()
        {
            WorkerName = "Male2",
            Earnings = 35E2,
            SpeedBonus = 1,
            HappinessBonus = 0.9
        };

        Male3 = new WorkerProperties()
        {
            WorkerName = "Male3",
            Earnings = 15E2,
            SpeedBonus = 0.8,
            HappinessBonus = 0.7
        };

        Female1 = new WorkerProperties()
        {
            WorkerName = "Female1",
            Earnings = 5E3,
            SpeedBonus = 1.1,
            HappinessBonus = 1.2
        };

        Female2 = new WorkerProperties()
        {
            WorkerName = "Female2",
            Earnings = 35E2,
            SpeedBonus = 0.9,
            HappinessBonus = 1
        };

        Female3 = new WorkerProperties()
        {
            WorkerName = "Female3",
            Earnings = 15E2,
            SpeedBonus = 0.7,
            HappinessBonus = 0.8
        };

        ////////////////////Male1////////////////////
        male1Earnings.text = "Salary: " + Male1.Earnings.ToString();
        male1SpeedBonus.text = "Speed Bonus: " + Male1.SpeedBonus.ToString();
        male1HappinessBonus.text = "Happiness Bonus: " + Male1.HappinessBonus.ToString();

        ////////////////////Male2////////////////////
        male2Earnings.text = "Salary: " + Male2.Earnings.ToString();
        male2SpeedBonus.text = "Speed Bonus: " + Male2.SpeedBonus.ToString();
        male2HappinessBonus.text = "Happiness Bonus: " + Male2.HappinessBonus.ToString();

        ////////////////////Male3////////////////////
        male3Earnings.text = "Salary: " + Male3.Earnings.ToString();
        male3SpeedBonus.text = "Speed Bonus: " + Male3.SpeedBonus.ToString();
        male3HappinessBonus.text = "Happiness Bonus: " + Male3.HappinessBonus.ToString();

        ////////////////////Female1////////////////////
        female1Earnings.text = "Salary: " + Female1.Earnings.ToString();
        female1SpeedBonus.text = "Speed Bonus: " + Female1.SpeedBonus.ToString();
        female1HappinessBonus.text = "Happiness Bonus: " + Female1.HappinessBonus.ToString();

        ////////////////////Female2////////////////////
        female2Earnings.text = "Salary: " + Female2.Earnings.ToString();
        female2SpeedBonus.text = "Speed Bonus: " + Female2.SpeedBonus.ToString();
        female2HappinessBonus.text = "Happiness Bonus: " + Female2.HappinessBonus.ToString();

        ////////////////////Female3////////////////////
        female3Earnings.text = "Salary: " + Female3.Earnings.ToString();
        female3SpeedBonus.text = "Speed Bonus: " + Female3.SpeedBonus.ToString();
        female3HappinessBonus.text = "Happiness Bonus: " + Female3.HappinessBonus.ToString();
    }

    void Update()
    {
        
    }
}
