using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageButtonController : MonoBehaviour
{
    MessageBehaviour message;
    BaseDataScript data;

    private void Start()
    {
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
        message = GameObject.Find("Messages").GetComponent<MessageBehaviour>();
    }

    public void DestroyObject()
    {
        data.canClick = true;
        Destroy(this.gameObject);
    }

    public void setButton(int i)
    {
        message.returnButton = i;
    }
}
