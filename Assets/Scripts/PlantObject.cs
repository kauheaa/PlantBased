using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public GameObject[] plantStates;
    public float timeBtwStates;
    public float timeBeforeWithering;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;
}
