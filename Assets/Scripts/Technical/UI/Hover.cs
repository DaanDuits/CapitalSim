using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField]
    Vector3 oldPos;

    [SerializeField]
    float lerpDuration;

    private void Start()
    {
        oldPos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        Vector3 a = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        float x = Mathf.Floor(a.x) + 0.5f;
        float y = Mathf.Floor(a.y) + 0.5f;
        Vector3 b = new Vector3(x, y, -5);
        this.transform.position = Vector3.Lerp(this.transform.position, b, lerpDuration * Time.deltaTime);
    }
}
