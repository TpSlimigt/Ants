using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(1,100)]
    public int antsToSpawn = 10;
    private List<GameObject> antList;

    public GameObject antPrefab;

    // Start is called before the first frame update
    void Start()
    {
        antList = new List<GameObject>();

        for (int i = 0; i < antsToSpawn; i++)
        {
            var spawnedAnt = Instantiate(antPrefab, transform.position, Quaternion.identity);//new GameObject("Ant " + (i + 1));
            spawnedAnt.name = "Ant " + (i + 1);
            spawnedAnt.transform.parent = transform;
            antList.Add(spawnedAnt);
        }
        Debug.Log("Ant list: " + antList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
