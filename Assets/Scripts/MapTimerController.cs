using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//TODO: Make those times beeing added to a timetable list

public class MapTimerController : MonoBehaviour
{
    public TextMeshPro CapitolFaraonCityTimer;
    public TextMeshPro CapitolMountainCityTimer;
    public TextMeshPro CapitolCloseToRussiaTimer;
    public TextMeshPro CapitolAlmostSnowTimer;
    public TextMeshPro AlmostSnowCloseToRussiaTimer;

    private float startTime;

    void Start()
    {
        if(AssetsPurchasedController.instance.confirmed == true)
        {
            AssetsPurchasedController.instance.ConfirmButton.onClick.AddListener(Update);
        }
        startTime = Time.time;
    }

    void Update()
    {
        float t = TrainSystem.instance.timeOfTravel - startTime;

        string minutes = ((int)t).ToString();
        string seconds = (t % 60).ToString("f0");

        if (TrainSystem.instance.sendFromDropdown.value == 1 && TrainSystem.instance.destinationDropdown.value == 2
         || TrainSystem.instance.sendFromDropdown.value == 2 && TrainSystem.instance.destinationDropdown.value == 1)
            CapitolAlmostSnowTimer.text = minutes + ":" + seconds;

        if (TrainSystem.instance.sendFromDropdown.value == 1 && TrainSystem.instance.destinationDropdown.value == 3
         || TrainSystem.instance.sendFromDropdown.value == 3 && TrainSystem.instance.destinationDropdown.value == 1)
            CapitolCloseToRussiaTimer.text = minutes + ":" + seconds;

        if (TrainSystem.instance.sendFromDropdown.value == 1 && TrainSystem.instance.destinationDropdown.value == 4
         || TrainSystem.instance.sendFromDropdown.value == 4 && TrainSystem.instance.destinationDropdown.value == 1)
            CapitolMountainCityTimer.text = minutes + ":" + seconds;

        if (TrainSystem.instance.sendFromDropdown.value == 1 && TrainSystem.instance.destinationDropdown.value == 5
         || TrainSystem.instance.sendFromDropdown.value == 5 && TrainSystem.instance.destinationDropdown.value == 1)
            CapitolFaraonCityTimer.text = minutes + ":" + seconds;

        
    }

    void TimeCountDown()
    {

    }
}