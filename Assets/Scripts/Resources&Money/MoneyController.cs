using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    float startMoney;

    public float money;

    [SerializeField]
    TMP_Text text;

    int sign = 0;

    [SerializeField]
    string[] letters;

    private void Start()
    {
        money = startMoney;
    }

    private void Update()
    {
        UpdateMoney();
    }

    void UpdateMoney()
    {
        if (sign == 0)
        {
            money = (int)money;
            text.text = money.ToString("0") + " " + letters[sign];
        }
        else
        {
            text.text = money.ToString("0.00") + " " + letters[sign];
        }
        if (money > 999)
        {
            money /= 1000;
            sign++;
        }
        if (money < -999)
        {
            money /= 1000;
            sign++;
        }
        if (sign != 0 && money < 1 && money > 0)
        {
            sign--;
            money *= 1000;
        }
        if (sign != 0 && money < 0 && money > -1)
        {
            sign--;
            money *= 1000;
        }
    }

    public void AddMoney(int addedMoney)
    {

        money += addedMoney / Mathf.Pow(1000, sign);
    }

    public void RemoveMoney(int removedMoney)
    {

        money -= removedMoney / Mathf.Pow(1000, sign);
    }
}
