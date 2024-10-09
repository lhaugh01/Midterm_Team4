using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;
      public GameObject maxScoreText;
      private int playerScore = 0;
      private int possibleScore = 0;

      void Start(){
            UpdateScore();
      }

      public void AddScore(int points){
            playerScore += points;
            UpdateScore();
      }

      public void AddFish(int points){
            possibleScore += points;
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
            scoreTextB.text = "Fish Fortune: $" + playerScore;
            Text scoreTextC = maxScoreText.GetComponent<Text>();
            scoreTextC.text = "Total Fish: " + possibleScore;
      }
}