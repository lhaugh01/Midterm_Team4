using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;  // Array to hold different fish prefabs
    public float spawnMin = .3f;  // Lower limit on spawn delay
    public float spawnMax = .5f;  // Upper limit on spawn delay
    public float oceanWidth = 16f;  // Width of your ocean
    public float minY = -4f; // Minimum Y position
    public float maxY = -1f; // Maximum Y position
    private GameHandler gameHandlerObj;

    void Start(){
        if (GameObject.FindWithTag("GameHandler") != null){
             gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            // Wait for the specified interval
            float randomDelay = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(randomDelay);

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
            if(randomFish < 16.6f)
            {
                index = 0;
            } 
            else if(randomFish < 33.3f)
            {
                index = 1;
            }
            else if (randomFish < 49.9f)
            {
                index = 2;
            }
            else if (randomFish < 66.5f)
            {
                index = 3;
            }
            else if (randomFish < 83.1f)
            {
                index = 4;
            }
            else {
                index = 5;
            }
            
            
            

            GameObject selectedFish = fishPrefabs[index];
            //int randomIndex = Random.Range(0, fishPrefabs.Length);
            //GameObject selectedFish = fishPrefabs[randomIndex];

            // Spawn the random fish at the random position
            GameObject newFish = Instantiate(selectedFish, spawnPosition,
                                            Quaternion.identity);
            int scoreValue = GetScoreValueByTag(newFish);
            Debug.Log("Score Value is: " + scoreValue);
            // int scoreValue = 1;
            gameHandlerObj.AddFish(scoreValue);
            
        }
    }
    private int GetScoreValueByTag(GameObject fish)
    {
        // Using the tag of the current GameObject
        switch (fish.tag) 
        {
            case "small":
                return 3; // Score for small fish
            case "medium":
                return 2; // Score for medium fish
            case "big":
                return 1; // Score for big fish
            case "bottle": // Negative score for bad items
            case "baggy":
            case "dead":
                return -1; // Subtract score for these items
            default:
                return 0; // Default score if the tag doesn't match
        }
    }
}
