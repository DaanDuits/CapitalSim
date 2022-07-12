using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGen : MonoBehaviour
{
    [SerializeField]
    TerrainData[] terrain;

    [SerializeField]
    FoliageData[] foliage;

    public int mapWidth;
    public int mapHeight;
    public int seed;

    [SerializeField]
    Vector2 offset;

    [SerializeField]
    Tilemap terrainMap;
    [SerializeField]
    Tilemap foliageMap;

    [SerializeField]
    NoiseValues[] values;

    [System.Serializable]
    [SerializeField]
    struct NoiseValues
    {
        public float scale;
        public int octaves;
        public float persistance;
        public float lacunarity;
    }

    private void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld()
    {
        float[,] biomeNoise = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, values[1].scale, values[1].octaves, values[1].persistance, values[1].lacunarity, offset);
        float[,] terrainNoise = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, values[0].scale, values[0].octaves, values[0].persistance, values[0].lacunarity, offset);

        for (int i = 0; i < terrain.Length; i++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (terrain[i].heightValue.x <= terrainNoise[x, y] && terrain[i].heightValue.y >= terrainNoise[x, y])
                        if (terrain[i].biomeValue.x <= biomeNoise[x,y] && terrain[i].biomeValue.y >= biomeNoise[x,y])
                            terrainMap.SetTile(terrainMap.WorldToCell(new Vector3(x, y, 0)), terrain[i].tile);
                }
            }
        }

        for (int i = 0; i < foliage.Length; i++)
        {
            float[,] foliageNoise = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, foliage[i].scale, foliage[i].octaves, foliage[i].persistance, foliage[i].lacunarity, offset);
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (foliage[i].heightvalue.x <= terrainNoise[x, y] && foliage[i].heightvalue.y >= terrainNoise[x, y])
                        if (foliage[i].density.x <= foliageNoise[x, y] && foliage[i].density.y >= foliageNoise[x, y])
                            if (foliage[i].biomeValue.x <= biomeNoise[x,y] && foliage[i].biomeValue.y >= biomeNoise[x,y])
                                foliageMap.SetTile(foliageMap.WorldToCell(new Vector3(x, y, 0)), foliage[i].tile);
                }
            }
        }
    }
}

