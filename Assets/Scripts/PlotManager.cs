using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlanted = false;
    public GameObject plant;
    public GameObject[] plantStates;

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

            if (timer < 0 && plantState < plantStates.Length - 1)
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
            if (plantState == plantStates.Length - 1 && !fm.isPlanting)
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
        plant.SetActive(false);
        fm.Transaction(selectedPlant.sellPrice);
    }

    void Plant(PlantObject newPlant)
    {
        Debug.Log("Planted " + plant.name);
        selectedPlant = newPlant;
        isPlanted = true;

        fm.Transaction(-selectedPlant.buyPrice);

        plantState = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStates;

        plantStates[0].SetActive(true);
        plant.SetActive(true);
    }

    void UpdatePlant()
    {
        plant = plantStates[plantState];

        if (plantState == 0)
        {
            plantStates[0].SetActive(true);

            plantStates[3].SetActive(false);
            plantStates[2].SetActive(false);
            plantStates[1].SetActive(false);
        }
        if (plantState == 1)
        {
            plantStates[1].SetActive(true);
            //Debug.Log(selectedPlant.plantStates[1].name + " " );
            plantStates[3].SetActive(false);
            plantStates[2].SetActive(false);
            plantStates[0].SetActive(false);
        }
        if (plantState == 2)
        {
            plantStates[2].SetActive(true);
            
            plantStates[3].SetActive(false);
            plantStates[1].SetActive(false);
            plantStates[0].SetActive(false);
        }
        if (plantState == 3)
        {
            plantStates[3].SetActive(true);
            plantStates[2].SetActive(false);
            plantStates[1].SetActive(false);
            plantStates[0].SetActive(false);
        }
    }
}
