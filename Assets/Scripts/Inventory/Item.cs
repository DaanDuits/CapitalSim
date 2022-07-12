using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    public BaseItemData itemData;

    public int amount;

    void Update()
    {
        if (amount < 2)
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            text.gameObject.SetActive(true);
            text.text = amount.ToString();
        }
    }
}
