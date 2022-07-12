using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Capitalism Sim/Data/Terrain Data")]
public class TerrainData : ScriptableObject
{
    public TileBase tile;
    public Vector2 heightValue;
    public Vector2 biomeValue;

    public float scale;
    public int octaves;
    public float persistance;
    public float lacunarity;

}
