using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    BaseDataScript data;

    private void Start()
    {
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        data.canClick = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        data.canClick = true;
    }
}
