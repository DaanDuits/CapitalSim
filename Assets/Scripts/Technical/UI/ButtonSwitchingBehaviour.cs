using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitchingBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform[] buttons;

    BaseDataScript data;

    private void Start()
    {
        data = GameObject.Find("BaseData").GetComponent<BaseDataScript>();
        buttons[data.mode].position += new Vector3(0, 15);
    }

    public void SetType(int i)
    {
        int prev = data.mode;
        data.mode = i;

        for (int j = 0; j < buttons.Length; j++)
        {
            if (j == prev)
                buttons[j].position -= new Vector3(0, 15);
            if (j == i)
                buttons[i].position += new Vector3(0, 15);
        }
    }
}
