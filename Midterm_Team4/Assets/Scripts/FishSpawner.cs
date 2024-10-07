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

    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Choose a random position along the width of the ocean
            float randomX = Random.Range(-oceanWidth / 2f, oceanWidth / 2f);
            float randomY = Random.Range(minY, maxY);  // Random Y position between minY and maxY
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Choose a random fish prefab
            int randomIndex = Random.Range(0, fishPrefabs.Length);
            GameObject selectedFish = fishPrefabs[randomIndex];

            // Spawn the random fish at the random position
            Instantiate(selectedFish, spawnPosition, Quaternion.identity);
        }
    }
}
