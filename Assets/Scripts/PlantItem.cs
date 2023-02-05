using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public TMP_Text nameTxt;
    public TMP_Text priceTxt;
    public Image icon;


    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();

        InitializeUI();
    }

    public void BuyPlant()
    {
        fm.SelectPlant(this);
        //transform.GetChild(1).GetComponent<Button>().interactable = false;
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }
}
