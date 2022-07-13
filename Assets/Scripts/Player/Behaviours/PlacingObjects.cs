using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlacingObjects : MonoBehaviour
{
    BaseDataScript data;

    [SerializeField]
    Color color;
    [SerializeField]
    Color red;
    [SerializeField]
    Color white;

    private void Start()
    {
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
    }

    public void PlaceOverTime(int ID, GameObject slot)
    {
        slot.SetActive(false);
        data.inventoryMode = 1;
        GameObject newObject = Instantiate(data.buildings[ID].placingObject);

        StartCoroutine(WaitForMouseAndBuild());
        IEnumerator WaitForMouseAndBuild()
        {
            while (true)
            {
                Vector3Int pos = data.foliage.WorldToCell(data.mousePos);
                for (int i = 0; i < data.buildings[ID].placeAbleTerrain.Length; i++)
                {
                    if (!data.buildings[ID].placedOnObjects && !data.foliage.HasTile(pos) && data.land.HasTile(pos) && data.buildings[ID].placeAbleTerrain[i] == data.terrain.GetTile(pos))
                    {
                        newObject.GetComponent<SpriteRenderer>().color = white;
                        break;
                    }
                    else if (data.buildings[ID].placedOnObjects && data.foliage.HasTile(pos) && data.land.HasTile(pos) && data.buildings[ID].placeAbleTerrain[i] == data.foliage.GetTile(pos))
                    {
                        newObject.GetComponent<SpriteRenderer>().color = white;
                        break;
                    }
                    else
                    {
                        newObject.GetComponent<SpriteRenderer>().color = red;
                    }
                }
                if (Input.GetMouseButton(0))
                {
                    Vector3 worldPos = data.foliage.CellToWorld(pos);
                    if (!data.buildings[ID].placedOnObjects && !data.foliage.HasTile(pos) && data.land.HasTile(pos))
                    {
                        for (int i = 0; i < data.buildings[ID].placeAbleTerrain.Length; i++)
                        {
                            if (data.terrain.GetTile(pos) == data.buildings[ID].placeAbleTerrain[i])
                            {
                                data.inventoryMode = 0;
                                Destroy(newObject);
                                Destroy(slot);
                                GameObject newSlider = Instantiate(data.slider, data.worldCanvas.transform);
                                newSlider.transform.position = worldPos + new Vector3(0.5f, 0.5f);
                                newSlider.GetComponent<Slider>().maxValue = data.buildings[ID].placingTime;
                                newSlider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = color;
                                while (true)
                                {
                                    newSlider.GetComponent<Slider>().value += Time.deltaTime;
                                    if (newSlider.GetComponent<Slider>().value == newSlider.GetComponent<Slider>().maxValue)
                                    {
                                        Destroy(newSlider);
                                        data.foliage.SetTile(pos, data.buildings[ID].tile);
                                        yield break;
                                    }
                                    yield return new WaitForEndOfFrame();
                                }
                            }
                        }
                    }
                }
                if (Input.GetMouseButton(1) || data.mode != 0)
                {
                    slot.SetActive(true);
                    data.inventoryMode = 0;
                    Destroy(newObject);
                    break;
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
