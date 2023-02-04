using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    public SpriteRenderer plot;

    PlotManager manager;
    FarmManager fm;

    void Start()
    {
        fm = transform.parent.GetComponent<FarmManager>();
    }

    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if (manager.isPlanted || fm.selectPlant.plant.buyPrice > fm.money)
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
}
