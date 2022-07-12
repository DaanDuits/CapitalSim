using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    GameObject inv; 
    [SerializeField]
    Transform invSlotHolder;

    BaseDataScript data;
    
    Transform cursor;

    List<bool> isFull = new List<bool>();
    List<Transform> slots = new List<Transform>();

    [System.Serializable]
    struct startingItem
    {
        public GameObject item;
        public int amount;
    }
    [SerializeField]
    List<startingItem> startingItems;

    public int currentSlot;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Cursor").transform;
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
        inv = this.transform.GetChild(0).gameObject;
        invSlotHolder = inv.transform.GetChild(0);

        InitializeInv();
        SetSlotIDs();
        CheckSlots();
        AddStartingItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.mode != 0)
        {
            inv.SetActive(false);
        }
        if (inv.activeSelf)
        {
            cursor.position = Input.mousePosition;
        }
    }

    void InitializeInv()
    {
        for (int i = 0; i < invSlotHolder.childCount; i++)
        {
            slots.Add(invSlotHolder.GetChild(i));
            isFull.Add(false);
        }
    }
    void SetSlotIDs()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent<Slot>() != null)
            {
                slots[i].GetComponent<Slot>().ID = i;
            }
        }
    }
    void CheckSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount > 0)
                isFull[i] = true;
            else
                isFull[i] = false;
        }
    }
    void AddStartingItems()
    {
        for (int i = 0; i < startingItems.Count; i++)
        {
            AddItem(startingItems[i].item, startingItems[i].amount);
        }
    }

    public void AddItem(GameObject item, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            for (int j = 0; j < slots.Count; j++)
            {
                if (isFull[j] && slots[j].GetChild(0).GetComponent<Item>().itemData.ID == item.GetComponent<Item>().itemData.ID)
                {
                    i = j;
                    break;
                }
            }
            if (amount == 0)
            {
                CheckSlots();
                return;
            }
            if (!isFull[i])
            {
                Instantiate(item, slots[i]);
                amount--;
            }
            if (slots[i].GetChild(0).GetComponent<Item>().itemData.ID == item.GetComponent<Item>().itemData.ID && slots[i].GetChild(0).GetComponent<Item>().amount < slots[i].GetChild(0).GetComponent<Item>().itemData.maxStack)
            {
                while (slots[i].GetChild(0).GetComponent<Item>().amount < slots[i].GetChild(0).GetComponent<Item>().itemData.maxStack && amount > 0)
                {
                    amount--;
                    slots[i].GetChild(0).GetComponent<Item>().amount++;
                }
                if (amount > 0)
                {
                    i = 0;
                }
            }
        }
    }

    public void PickupDrop()
    {
        int cursorChildren = cursor.childCount;
        int currentSlotChildren = slots[currentSlot].childCount;

        switch (currentSlotChildren, cursorChildren)
        {
            case (1, 0):
                Instantiate(slots[currentSlot].GetChild(0).gameObject, cursor);
                Destroy(slots[currentSlot].GetChild(0).gameObject);
                return;
            case (0, 1):
                Instantiate(cursor.GetChild(0).gameObject, slots[currentSlot]);
                Destroy(cursor.GetChild(0).gameObject);
                return;
            case (0, 0):
                return;
            case (1, 1):
                return;
        }
    }
    public void PickupDropHalf()
    {

    }
}
