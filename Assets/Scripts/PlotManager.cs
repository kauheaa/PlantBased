using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlanted = false;
    GameObject plant;

    int plantState = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    public SpriteRenderer plot;

    PlantObject selectedPlant;

    FarmManager fm;

    //bool isDry = false;
    //public GameObject dryPlant;

    // Start is called before the first frame update
    void Start()
    {
        fm = transform.parent.GetComponent<FarmManager>();
        plant = transform.GetChild(0).gameObject;
        
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
        plant.SetActive(false);
        fm.Transaction(selectedPlant.sellPrice);

        plantState = 0;

        if (selectedPlant.plantName == "Carrot")
        {
            transform.GetChild(8).gameObject.SetActive(false);
        }
        if (selectedPlant.plantName == "Beet")
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
        if (selectedPlant.plantName == "Onion")
        {
            transform.GetChild(4).gameObject.SetActive(false);
        }
        if (selectedPlant.plantName == "Radish")
        {
            transform.GetChild(6).gameObject.SetActive(false);
        }
        if (selectedPlant.plantName == "Turnip")
        {
            transform.GetChild(7).gameObject.SetActive(false);
        }
        if (selectedPlant.plantName == "Potato")
        {
            transform.GetChild(5).gameObject.SetActive(false);
        }
    }

    void Plant(PlantObject newPlant)
    {
        plant.SetActive(true);
        selectedPlant = newPlant;
        isPlanted = true;

        fm.Transaction(-selectedPlant.buyPrice);
        fm.isPlanting = false;

        plantState = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStates;

        //StartCoroutine(DryingPlant());
    }

    void UpdatePlant()
    {
        plant = selectedPlant.plantStates[plantState];

        if (selectedPlant.plantName == "Carrot")
        {
            Carrot();
        }
        if (selectedPlant.plantName == "Beet")
        {
            Beet();
        }
        if (selectedPlant.plantName == "Onion")
        {
            Onion();
        }
        if (selectedPlant.plantName == "Radish")
        {
            Radish();
        }
        if (selectedPlant.plantName == "Turnip")
        {
            Turnip();
        }
        if (selectedPlant.plantName == "Potato")
        {
            Potato();
        }


    }
 
    void Carrot()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        if (plantState == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (plantState == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(8).gameObject.SetActive(true);
        }
    }
    void Beet()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        if (plantState == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if (plantState == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (plantState == 3)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }
    void Onion()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        if (plantState == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (plantState == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    void Turnip()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        if (plantState == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (plantState == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(7).gameObject.SetActive(true);
        }
    }
    void Radish()
    {


        transform.GetChild(0).gameObject.SetActive(true);
        if (plantState == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (plantState == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(true);
        }
    }
    void Potato()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        if (plantState == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (plantState == 2)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(true);
        }
    }
}
