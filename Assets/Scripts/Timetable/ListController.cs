using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListController : MonoBehaviour
{
    private TextMeshProUGUI departureCity;
    private TextMeshProUGUI destinationCity;
    private TextMeshProUGUI trainPicked;
    private TextMeshProUGUI staffPicked;
    private TextMeshProUGUI ETA;

    public void SetList(string departureCityStr, string destinationCityStr, string trainPickedStr, string staffPickedStr, string ETAStr)
    {
        departureCity.text = departureCityStr;
        destinationCity.text = destinationCityStr;
        trainPicked.text = trainPickedStr;
        staffPicked.text = staffPickedStr;
        ETA.text = ETAStr;
    }

    void Start()
    {
       // AssetsPurchasedController.instance.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
