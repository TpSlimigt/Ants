using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(1,100)]
    public int antsToSpawn = 10;
    private List<GameObject> antList;
    private int foodCollected;

    public GameObject antPrefab;
    public GameObject foodText;

    // Start is called before the first frame update
    void Start()
    {
        antList = new List<GameObject>();

        for (int i = 0; i < antsToSpawn; i++)
        {
            var spawnedAnt = Instantiate(antPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f), Quaternion.identity);//new GameObject("Ant " + (i + 1));
            spawnedAnt.name = "Ant " + (i + 1);
            //spawnedAnt.transform.parent = transform;
            spawnedAnt.GetComponent<Ant>().homePos = gameObject.transform.position;
            spawnedAnt.GetComponent<Ant>().homeObject = gameObject;
            antList.Add(spawnedAnt);
        }
        Debug.Log("Ant list: " + antList.Count);

        foodCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFoodCollected(int foodCount)
    {
        foodCollected += foodCount;
        foodText.GetComponent<TextMesh>().text = "Food collected: " + foodCollected;
    }
}
