using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range(0, 5)]
    public float zoomSensitivity = 1f;
    private int zoomMultiplier;
    //int foodName = 1;
    public GameObject foodPrefab;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        zoomMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0.0f;
            if (Instantiate(foodPrefab, mousePos, Quaternion.identity))
            {
                //Debug.Log(mousePos);
            }
            //GameObject spawnedFood = new GameObject("Food " + foodName);
        }

        // Camera zoom
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                zoomMultiplier = 5;
            }
            else
            {
                zoomMultiplier = 1;
            }
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity * zoomMultiplier;
            
            if (Camera.main.orthographicSize < 1)
            {
                Camera.main.orthographicSize = 1;
            }
        }
    }
}
