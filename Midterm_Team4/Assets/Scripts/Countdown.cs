using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For displaying UI text
using UnityEngine.SceneManagement; // For scene switching

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // Set the countdown time in seconds
    public Text timerText;
    public GameHandler gameHandlerObj;

    private bool timerIsRunning = false;

    void Start()
    {
        // Start the countdown timer
        timerIsRunning = true;
        if (GameObject.FindWithTag("GameHandler") != null){
             gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Reduce the time remaining
                timeRemaining -= Time.deltaTime;

                // Update the UI text with the formatted time
                DisplayTime(timeRemaining);
            }
            else
            {
                // When time runs out, stop the timer
                timeRemaining = 0;
                timerIsRunning = false;

                // Load the results scene
                EndGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Format the time (minutes:seconds)
        timeToDisplay += 1; // So it doesn't immediately show 00:00

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Update the UI text with the new time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        // Load the results scene
        gameHandlerObj.endGame();
    }
}
