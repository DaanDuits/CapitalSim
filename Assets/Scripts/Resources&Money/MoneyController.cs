using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    int startMoney;

    public int money;

    [SerializeField]
    TMP_Text text;

    private void Start()
    {
        money = startMoney;
    }

    private void Update()
    {
        text.text = money.ToString();
    }
}
