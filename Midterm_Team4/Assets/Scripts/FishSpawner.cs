// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FishSpawner : MonoBehaviour
// {
//     public GameObject fishPrefab;  // Reference to fish prefab
//     public float spawnInterval = 1f;  // Time between spawns
//     public float oceanWidth = 16f;  // Width of your ocean
//     public float minY = -4f; // Minimum Y position
//     public float maxY = -1f; // Maximum Y position

//     void Start()
//     {
//         StartCoroutine(SpawnFish());
//     }

//     IEnumerator SpawnFish()
//     {
//         while (true)
//         {
//             // Wait for the specified interval
//             yield return new WaitForSeconds(spawnInterval);

//             // Choose a random position along the width of the ocean
//             float randomX = Random.Range(-oceanWidth / 2f, oceanWidth / 2f);
//             float randomY = Random.Range(minY, maxY);  // Random Y position between minY and maxY
//             Vector2 spawnPosition = new Vector2(randomX, randomY);

//             // Spawn the fish at the random position
//             Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;  // Array to hold different fish prefabs
    public float spawnInterval = 1f;  // Time between spawns
    public float oceanWidth = 16f;  // Width of your ocean
    public float minY = -4f; // Minimum Y position
    public float maxY = -1f; // Maximum Y position
    public GameHandler gameHandlerObj;

    void Start(){
        StartCoroutine(SpawnFish());
          if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
          }
    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Choose a random position along the width of the ocean
            float randomX = Random.Range(2f, oceanWidth / 2f);
            float direction = Random.Range(-1f, 1f);
            if (direction <= 0f)
            {
                randomX *= -1;
            }
            float randomY = Random.Range(minY, maxY);  // Random Y position between minY and maxY
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Choose a random, weighted fish prefab
            int index = 0;
            float randomFish = Random.Range(0f, 100f);
            if(randomFish < 52.5f)
            {
                index = 0;
            } 
            else if(randomFish < 85f)
            {
                index = 1;
            }
            else
            {
                index = 2;
            }
            GameObject selectedFish = fishPrefabs[index];
            //int randomIndex = Random.Range(0, fishPrefabs.Length);
            //GameObject selectedFish = fishPrefabs[randomIndex];

            // Spawn the random fish at the random position
            Instantiate(selectedFish, spawnPosition, Quaternion.identity);
            //int scoreValue = GetScoreValueByTag(selectedFish);
            int scoreValue = 1;
            gameHandlerObj.AddFish(scoreValue);
            
        }
    }
    private int GetScoreValueByTag()
    {
        // Using the tag of the current GameObject
        switch (tag) 
        {
            case "small":
                return 3; // Score for small fish
            case "medium":
                return 2; // Score for medium fish
            case "big":
                return 1; // Score for big fish
            default:
                return 0; // Default score if the tag doesn't match
        }
    }
}
