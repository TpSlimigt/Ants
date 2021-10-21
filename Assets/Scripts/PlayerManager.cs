using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //int foodName = 1;
    public GameObject foodPrefab;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
