using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Capitalism Sim/Data/Foliage Data")]
public class FoliageData : ScriptableObject
{
    public TileBase tile;

    public Vector2 density;
    public Vector2 heightvalue;
    public Vector2 biomeValue;

    public float scale;
    public int octaves;
    public float persistance;
    public float lacunarity;
}
