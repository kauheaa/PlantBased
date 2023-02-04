using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlanted = false;
    public GameObject plant;

    int plantState = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    public SpriteRenderer plot;

    PlantObject selectedPlant;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = transform.parent.GetComponent<FarmManager>();
        //plot = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantState < selectedPlant.plantStates.Length - 1)
            {
                timer = selectedPlant.timeBtwStates;
                plantState++;
                UpdatePlant();
            }
        }
        Debug.Log(plantState);
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantState == selectedPlant.plantStates.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }
        }
        else if(fm.isPlanting && fm.selectPlant.plant.buyPrice <= fm.money)
        {
            Plant(fm.selectPlant.plant);
        }
    }
    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if (isPlanted || fm.selectPlant.plant.buyPrice > fm.money)
            {
                // cant buy
                plot.color = unavailableColor;
            }
            else
            {
                // you can buy
                plot.color = availableColor;
            }
        }
    }
    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        fm.Transaction(selectedPlant.sellPrice);
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;

        fm.Transaction(-selectedPlant.buyPrice);

        plantState = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStates;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant = selectedPlant.plantStates[plantState];

        if(plantState == 0)
        {
            selectedPlant.plantStates[0].SetActive(true);
            Debug.Log("PlantState on nolla");
            selectedPlant.plantStates[3].SetActive(false);
            selectedPlant.plantStates[2].SetActive(false);
            selectedPlant.plantStates[1].SetActive(false);
        }
        if (plantState == 1)
        {
            selectedPlant.plantStates[1].SetActive(true);
            Debug.Log("PlantState on yksi");
            selectedPlant.plantStates[3].SetActive(false);
            selectedPlant.plantStates[2].SetActive(false);
            selectedPlant.plantStates[0].SetActive(false);
        }
        if (plantState == 2)
        {
            selectedPlant.plantStates[2].SetActive(true);
            Debug.Log("PlantState on kaksi");
            selectedPlant.plantStates[3].SetActive(false);
            selectedPlant.plantStates[1].SetActive(false);
            selectedPlant.plantStates[0].SetActive(false);
        }
        if (plantState == 3)
        {
            selectedPlant.plantStates[3].SetActive(true);
            Debug.Log("PlantState on kolme");
            selectedPlant.plantStates[2].SetActive(false);
            selectedPlant.plantStates[1].SetActive(false);
            selectedPlant.plantStates[0].SetActive(false);
        }
    }
}
