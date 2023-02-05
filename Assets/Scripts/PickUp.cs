using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    PlotManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = transform.parent.GetComponent<PlotManager>();

    }

    public void PlopSound()
    {
        AudioManagerScript.PlaySound("plop");
    }

    public void FinishPickup()
    {
        pm.PickUpEvent();
        pm.money();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
