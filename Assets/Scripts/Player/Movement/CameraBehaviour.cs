using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    TerrainGen generator;
    Camera cam;

    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.Find("TerrainGenerator").GetComponent<TerrainGen>();
        cam = this.GetComponent<Camera>();

        this.transform.position = new Vector3(generator.mapWidth / 2, generator.mapHeight / 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(2))
        {
            Vector3 distance = pos - cam.ScreenToWorldPoint(Input.mousePosition);

            this.transform.position += distance;
        }

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, 10.65f, generator.mapWidth - 10.65f), Mathf.Clamp(this.transform.position.y, 6, generator.mapHeight - 6), -10);
    }
}
