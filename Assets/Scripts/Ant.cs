using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    // Movement of the ant
    private float speed;
    private float angle;
    [Range(0,2)]
    public float steeringStrength;
    private Vector3 direction;
    private Vector3 position;

    // Direction of the ant
    private Vector3 desiredDirection;
    private Vector3 currentDirection;

    // Food variables
    public GameObject target;
    private int foodCount;
    public bool followFood;
    public bool addedToList;

    // Raycast
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        direction = new Vector3(0, 0, 0);
        steeringStrength = 0.05f;
        followFood = false;
        addedToList = false;
        foodCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            followFood = false;
        }

        if (followFood)
        {
            //Direction towards target
            direction = (target.transform.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            position = direction * speed * Time.deltaTime;
        }
        else
        {
            //Random direction
            var xDir = Random.Range(-1.0f, 1.0f);
            var yDir = Random.Range(-1.0f, 1.0f);
            desiredDirection = (desiredDirection + new Vector3(xDir, yDir, 0) * steeringStrength).normalized;
            position = desiredDirection * speed * Time.deltaTime;
            angle = Mathf.Atan2(desiredDirection.y, desiredDirection.x) * Mathf.Rad2Deg;
        }

        //Updates position and rotation of the ant
        transform.SetPositionAndRotation(transform.position += position, Quaternion.Euler(0, 0, angle - 90));

        // Raycast
        ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up, Color.red); // Draws red debug lines

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.transform.CompareTag("Food"))
            {
                target = hit.transform.gameObject;

                // Only goes for food if it is not targeted by an another ant
                if (!target.GetComponent<Food>().isTargeted)
                {
                    target.GetComponent<Food>().AddTargeted(gameObject);
                    followFood = true;
                }
            }
        }
    }
    // Called when ant is colliding with trigger volume (food).
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            target.GetComponent<Food>().FoodEaten();
            followFood = false;
            foodCount += 1;
            gameObject.name = "Ant, eaten: " + foodCount;
        }
    }
}
