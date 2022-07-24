using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Capitalism Sim/Data/Building")]
public class BuildingData : BaseItemData
{
    public TileBase tile;
    public TileBase[] placeableTerrain;
    public bool placedOnObjects;

    public float placingTime;

    public GameObject placingObject;
}
