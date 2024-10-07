using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public int numberOfObjects = 10;
    public Vector2 spawnAreaBL; //bottom left corner of spawn area
    public Vector2 spawnAreaTR; //top right corner of spawn area

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // generates a random spot within the spawn area
            Vector2 randomSpot = new Vector2(
                Random.Range(spawnAreaBL.x, spawnAreaTR.x),
                Random.Range(spawnAreaBL.y, spawnAreaTR.y)
            );

            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject prefabToSpawn = objectsToSpawn[randomIndex];

            Instantiate(prefabToSpawn, randomSpot, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
