using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money = 100;
    public TMP_Text moneyText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            selectPlant.priceTxt.text = "Buy $" + selectPlant.plant.buyPrice;
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            if(selectPlant != null)
            {
                selectPlant.priceTxt.text = "Buy $" + selectPlant.plant.buyPrice;
            }
            selectPlant = newPlant;

            selectPlant.priceTxt.text = "Cancel ";
            isPlanting = true;
        }
    }

    public void Transaction (int value)
    {
        money += value;
        moneyText.text = "$ " + money;
    }
}
