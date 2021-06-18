using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Chest", menuName ="Chest")]
public class Chest : ScriptableObject
{

    public enum ChestType { Common, Rare, Epic, Legendary };

    public ChestType chestType;

    public int gemMin;
    public int gemMax;

    public int coinsMin;
    public int coinsMax;

    //in minutes
    public int Timer;

    public Color color;

}
