using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseDataScript : MonoBehaviour
{
    public List<Vector3Int> ownedLandPositions;
    public Tilemap terrain;
    public Tilemap foliage;
    public Tilemap land;
    public TileBase landTile;

    public MoneyController moneyController;
    public PlacingObjects placing;

    public MessageBehaviour message;

    public Vector3 mousePos;

    
    Transform hover;

    public bool canClick = true;

    public int mode = 1;
    public int inventoryMode = 0;

    public BuildingData[] buildings;

    public GameObject worldCanvas;
    public GameObject slider;

    private void Start()
    {
        placing = GameObject.Find("Placing").GetComponent<PlacingObjects>();
        hover = GameObject.Find("Hover").transform;
        message = GameObject.Find("Messages").GetComponent<MessageBehaviour>();
        terrain = GameObject.Find("TerrainMap").GetComponent<Tilemap>();
        land = GameObject.Find("LandMap").GetComponent<Tilemap>();
        foliage = GameObject.Find("FoliageMap").GetComponent<Tilemap>();
        moneyController = GameObject.Find("Money").GetComponent<MoneyController>();
        worldCanvas = GameObject.Find("WorldCanvas");
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mode == 1 || mode == 2)
            hover.gameObject.SetActive(true);
        else
            hover.gameObject.SetActive(false);
    }

    public void AddOwnedLandPositions(Vector3Int pos)
    {
        ownedLandPositions.Add(pos);
    }
    public void RemoveOwnedLandPositions(Vector3Int pos)
    {
        ownedLandPositions.Remove(pos);
    }
}
