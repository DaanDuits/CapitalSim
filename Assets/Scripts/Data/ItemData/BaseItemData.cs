using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseItemData : ScriptableObject
{
    public int ID;
    public string itemName;
    public int maxStack;

    public bool placeable;
}
