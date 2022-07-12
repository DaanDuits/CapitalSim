using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingLand : MonoBehaviour
{
    BaseDataScript data;

    Vector3Int pos;

    private void Start()
    {
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
    }

    private void Update()
    {
        UpdateLand();
    }
    void UpdateLand()
    {
        if (Input.GetMouseButtonDown(0) && data.moneyController.money >= 50 && data.canClick && data.mode == 1)
        {
            pos = data.land.WorldToCell(data.mousePos);
            if (!data.land.HasTile(pos))
            {

                data.message.CreateQuestion("Are you sure you want to buy this piece of land for 50 coins?",
                    () =>
                    {
                        data.land.SetTile(pos, data.landTile);
                        data.AddOwnedLandPositions(pos);
                        data.moneyController.money -= 50;
                    });
            }
        }
    }
}
