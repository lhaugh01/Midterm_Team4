using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFish : MonoBehaviour
{
    private GameHandler gameHandlerObj;
    public GameObject particlesPrefab;

    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    private void OnMouseDown()
    {
        int scoreValue = GetScoreValueByTag();

        if (scoreValue == 3) {
            Debug.Log("adding small!");
        } else if (scoreValue == 2) {
            Debug.Log("adding med!");
        } else if (scoreValue == 1) {
            Debug.Log("adding big!");
        } else {
            Debug.Log("adding trash!");
        }
        gameHandlerObj.AddScore(scoreValue);

        // Optionally play a sound when an object is destroyed
        // gameObject.GetComponent<AudioSource>().Play();
        Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
            case "bottle": // Negative score for bad items
            case "baggy":
            case "urchin":
            case "coal":
            case "seaweed":
            case "dead":
                return -1; // Subtract score for these items
            default:
                return 0; // Default score if the tag doesn't match
        }
    }
}





