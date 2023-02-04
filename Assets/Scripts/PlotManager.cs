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

    public Color emptyColor = Color.white;
    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;
    public Color growingColor = Color.white;

    public SpriteRenderer plot;

    PlantObject selectedPlant;

    FarmManager fm;

    Animator m_Animator;

    //bool isDry = false;
    //public GameObject dryPlant;

    // Start is called before the first frame update
    void Start()
    {
        fm = transform.parent.GetComponent<FarmManager>();
        plant = transform.GetChild(0).gameObject;
        plot.color = emptyColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
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
                plot.color = emptyColor;
            }
            else
            {
                plot.color = unavailableColor;
            }
        }
        else if (fm.isPlanting && fm.selectPlant.plant.buyPrice <= fm.money)
        {
            Plant(fm.selectPlant.plant);
            plot.color = growingColor;
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
        else
        if (isPlanted)
        {
            // cant buy
            plot.color = growingColor;
        }
        else
        {
            plot.color = Color.white;
        }
    }

    private void OnMouseExit()
    {
        if (isPlanted)
        {
            plot.color = growingColor;
        }
        else
        {
            plot.color = emptyColor;
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.SetActive(false);
        fm.Transaction(selectedPlant.sellPrice);

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(7).gameObject.SetActive(false);

            plantState = 0;

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

    void Beet()
    {
        if(plantState == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (plantState == 1)
            {
                Debug.Log("state 1: teen");
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                if (plantState == 2)
                {
                    Debug.Log("state 2: adult");
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(true);
                    m_Animator = transform.GetChild(2).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Peek");
            }
                else
                {
                    if (plantState == 3)
                    {
                    m_Animator = transform.GetChild(2).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Wiggle");
                    Debug.Log("state 3: elder");
                   }   

                }

            }
    }

    void Carrot()
    {
        if (plantState == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (plantState == 1)
        {
            Debug.Log("state 1: teen");
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            if (plantState == 2)
            {
                Debug.Log("state 2: adult");
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                m_Animator = transform.GetChild(3).gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger("Peek");
            }
            else
            {
                if (plantState == 3)
                {
                    m_Animator = transform.GetChild(3).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Wiggle");
                    Debug.Log("state 3: elder");
                }

            }

        }
    }

    void Onion()
    {
        if (plantState == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (plantState == 1)
        {
            Debug.Log("state 1: teen");
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            if (plantState == 2)
            {
                Debug.Log("state 2: adult");
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(true);
                m_Animator = transform.GetChild(4).gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger("Peek");
            }
            else
            {
                if (plantState == 3)
                {
                    m_Animator = transform.GetChild(4).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Wiggle");
                    Debug.Log("state 3: elder");
                }

            }

        }
    }
    void Potato()
    {
        if (plantState == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (plantState == 1)
        {
            Debug.Log("state 1: teen");
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            if (plantState == 2)
            {
                Debug.Log("state 2: adult");
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(5).gameObject.SetActive(true);
                m_Animator = transform.GetChild(5).gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger("Peek");
            }
            else
            {
                if (plantState == 3)
                {
                    m_Animator = transform.GetChild(5).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Wiggle");
                    Debug.Log("state 3: elder");
                }

            }

        }
    }
    void Radish()
    {
        if (plantState == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (plantState == 1)
        {
            Debug.Log("state 1: teen");
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            if (plantState == 2)
            {
                Debug.Log("state 2: adult");
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(true);
                m_Animator = transform.GetChild(6).gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger("Peek");
            }
            else
            {
                if (plantState == 3)
                {
                    m_Animator = transform.GetChild(6).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Wiggle");
                    Debug.Log("state 3: elder");
                }

            }

        }
    }
    void Turnip()
    {
        if (plantState == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (plantState == 1)
        {
            Debug.Log("state 1: teen");
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            if (plantState == 2)
            {
                Debug.Log("state 2: adult");
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(7).gameObject.SetActive(true);
                m_Animator = transform.GetChild(7).gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger("Peek");
            }
            else
            {
                if (plantState == 3)
                {
                    m_Animator = transform.GetChild(7).gameObject.GetComponent<Animator>();
                    m_Animator.SetTrigger("Wiggle");
                    Debug.Log("state 3: elder");
                }

            }

        }
    }
}
