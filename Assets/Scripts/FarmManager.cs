using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money = 10;
    public TMP_Text moneyText;

    public bool isSelecting = false;
    public int selectedTool = 0;

    public Image[] buttonsImg;
    public Sprite normalButton;
    public Sprite selectedButton;


    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$ " + money;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            CheckSelection();
        }
        else
        {
            CheckSelection();
            selectPlant = newPlant;

            selectPlant.priceTxt.text = "Cancel ";
            isPlanting = true;
        }
    }

    public void SelectTool(int toolNumber)
    {
        if(toolNumber == selectedTool)
        {
            // deselect
            CheckSelection();
        }
        else
        {
            // select
            CheckSelection();
            isSelecting = true;
            selectedTool = toolNumber;
            buttonsImg[toolNumber - 1].sprite = selectedButton;
        }
    }

    void CheckSelection()
    {
        if(isPlanting)
        {
            isPlanting = false;
            if (selectPlant != null)
            {
                selectPlant.priceTxt.text = "Buy $" + selectPlant.plant.buyPrice;
                selectPlant = null;
            }
        }
        if (isSelecting)
        {
            if(selectedTool>0)
            {
                buttonsImg[selectedTool - 1].sprite = normalButton;
            }
            isSelecting = false;
            selectedTool = 0;
        }
    }

    public void Transaction (int value)
    {
        money += value;
        moneyText.text = "$ " + money;
    }
}
