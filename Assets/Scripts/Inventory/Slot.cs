using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public int ID;

    InventoryManager manager;

    BaseDataScript data;

    private void Start()
    {
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            manager.currentSlot = ID;
            manager.PickupDrop();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            manager.currentSlot = ID;
            if (this.transform.childCount > 0 && this.transform.GetChild(0).GetComponent<Item>().itemData.placeable && data.inventoryMode == 0)
            {
                data.placing.PlaceOverTime(this.transform.GetChild(0).GetComponent<Item>().itemData.ID, this.transform.GetChild(0).gameObject);
            }
            else if (this.transform.childCount < 1 && data.inventoryMode == 0)
            {
                manager.PickupDropHalf();
            }
        }
    }
}
