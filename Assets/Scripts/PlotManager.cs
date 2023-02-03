using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    bool isPlanted = false;
    GameObject plant;

    public GameObject[] plantStates;
    int plantState = 0;
    float timeBtwStates = 2f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantState < plantStates.Length - 1)
            {
                timer = timeBtwStates;
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
            if (plantState == plantStates.Length - 1)
            {
                Harvest();
            }
        }
        else
        {
            Plant();
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        isPlanted = true;
        plantState = 0;
        UpdatePlant();
        timer = timeBtwStates;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant = plantStates[plantState];

        if(plantState == 0)
        {
            plantStates[0].SetActive(true);

            plantStates[3].SetActive(false);
            plantStates[2].SetActive(false);
            plantStates[1].SetActive(false);
        }
        if (plantState == 1)
        {
            plantStates[1].SetActive(true);

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
