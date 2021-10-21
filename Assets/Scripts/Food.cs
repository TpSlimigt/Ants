using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //private Vector3 mousePos;
    private GameObject currentlyTargeting;
    public bool isTargeted;

    // Start is called before the first frame update
    void Start()
    {
        isTargeted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    // Assigns targeted ant to a variable to update later when the food is removed.
    public void AddTargeted(GameObject targeting)
    {
        currentlyTargeting = targeting;
        isTargeted = true;
    }

    // "Releases" an ant from the food so it can go and look for more.
    public void FoodEaten()
    {
        currentlyTargeting.GetComponent<Ant>().followFood = false;
        currentlyTargeting.GetComponent<Ant>().addedToList = false;
        Destroy(gameObject);
    }
}
