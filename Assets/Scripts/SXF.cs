using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SXF : MonoBehaviour
{

    public AudioSource src;
    public AudioClip plant, plop, money, birds;

    public void PlayPlant()
    {
        src.clip = plant;
        src.Play();
    }

    public void PlayPlop()
    {
        src.clip = plop;
        src.Play();

    }


    public void PlayMoney()
    {
        src.clip = money;
        src.Play();

    }


    public void PlayBirds()
    {
        src.clip = birds;
        src.Play();

    }
}
