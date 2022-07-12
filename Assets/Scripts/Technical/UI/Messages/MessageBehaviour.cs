using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject messageObject;
    [SerializeField]
    Transform canvas;

    public int returnButton;

    public void CreateMessage(string text)
    {
        GameObject newMessage = Instantiate(messageObject, canvas);
        newMessage.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
        newMessage.transform.GetChild(1).gameObject.SetActive(true);
        newMessage.transform.GetChild(2).gameObject.SetActive(false);
        newMessage.transform.GetChild(3).gameObject.SetActive(false);
    }

    public void CreateQuestion(string text, Action action)
    {
        GameObject newQuestion = Instantiate(messageObject, canvas);
        newQuestion.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
        newQuestion.transform.GetChild(1).gameObject.SetActive(false);
        newQuestion.transform.GetChild(2).gameObject.SetActive(true); 
        newQuestion.transform.GetChild(3).gameObject.SetActive(true);

        StartCoroutine(WaitForButton());
        IEnumerator WaitForButton()
        {
            while (true)
            {
                if (returnButton == 1)
                {
                    returnButton = 0;
                    action();
                }
                else if (returnButton == 2)
                {
                    returnButton = 0;
                    break;
                }
                yield return new WaitForEndOfFrame();   
            }
        }
    }


}
