using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    bool isPlanted = false;
    GameObject plant;

    int plantState = 0;
    float timer;

    PlantObject selectedPlant;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = transform.parent.GetComponent<FarmManager>();
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
                Debug.Log("úpdated?");
            }
        }
        Debug.Log(plantState);
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantState == selectedPlant.plantStates.Length - 1)
            {
                Harvest();
            }
        }
        else if(fm.isPlanting)
        {
            Plant(fm.selectPlant.plant);
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;
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

            selectedPlant.plantStates[3].SetActive(false);
            selectedPlant.plantStates[2].SetActive(false);
            selectedPlant.plantStates[1].SetActive(false);
        }
        if (plantState == 1)
        {
            selectedPlant.plantStates[1].SetActive(true);

            selectedPlant.plantStates[3].SetActive(false);
            selectedPlant.plantStates[2].SetActive(false);
            selectedPlant.plantStates[0].SetActive(false);
        }
        if (plantState == 2)
        {
            selectedPlant.plantStates[2].SetActive(true);

            selectedPlant.plantStates[3].SetActive(false);
            selectedPlant.plantStates[1].SetActive(false);
            selectedPlant.plantStates[0].SetActive(false);
        }
        if (plantState == 3)
        {
            selectedPlant.plantStates[3].SetActive(true);

            selectedPlant.plantStates[2].SetActive(false);
            selectedPlant.plantStates[1].SetActive(false);
            selectedPlant.plantStates[0].SetActive(false);
        }
    }
}
