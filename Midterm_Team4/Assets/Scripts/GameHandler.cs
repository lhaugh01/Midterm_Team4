using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;
      public GameObject maxScoreText;
      public GameObject smallFishText;
      public GameObject medFishText;
      public GameObject bigFishText;
      public GameObject trashFishText;
      
      public static class GameData
      {
            public static int playerScore;
            public static int caughtTrash;
            public static int caughtBig;
            public static int caughtMed;
            public static int caughtSmall;
            public static int totalTrash;
            public static int totalBig;
            public static int totalMed;
            public static int totalSmall;
            public static int totalItems;
      }

      private int playerScore = 0;
      private int caughtTrash = 0;
      private int caughtBig = 0;
      private int caughtMed = 0;
      private int caughtSmall = 0;
      private int totalTrash = 0;
      private int totalBig = 0;
      private int totalMed = 0;
      private int totalSmall = 0;
      private int totalItems = 0;
 
      void Start(){
            UpdateScore();
      }

      public void AddScore(int points){
            playerScore += points;
            if(points == 3){
                  caughtSmall++;
                  Debug.Log("Curr Small: " + caughtSmall);
            }else if(points == 2){
                  caughtMed++;
                  Debug.Log("Curr Med: " + caughtMed);
            }else if(points == 1){
                  caughtBig++;
                  Debug.Log("Curr Big: " + caughtBig);
            }else{
                  caughtTrash++;
                  Debug.Log("Curr Trash: " + caughtTrash);
            }
            Debug.Log("Curr Score: " + playerScore);
            UpdateScore();
      }

      public void AddFish(int points){
            totalItems++;
            if(points == 3){
                  totalSmall++;
            }else if(points == 2){
                  totalMed++;
            }else if(points == 1){
                  totalBig++;
            }else{
                  totalTrash++;
            }
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
            scoreTextB.text = "Fish Fortune: $" + playerScore;
            Text scoreTextC = maxScoreText.GetComponent<Text>();
            scoreTextC.text = "Total Items: " + totalItems;
      
      }

      void writeResults(){
            Text smallText = smallFishText.GetComponent<Text>();
            smallText.text = "" + caughtSmall + "/" + totalSmall;
            Text medText = medFishText.GetComponent<Text>();
            medText.text = caughtMed + "/" + totalMed;
            Text bigText = bigFishText.GetComponent<Text>();
            bigText.text = caughtBig + "/" + totalBig;
            Text trashText = trashFishText.GetComponent<Text>();
            trashText.text = caughtTrash + "/" + totalTrash;
            Text scoreTextB = scoreText.GetComponent<Text>();
            scoreTextB.text = "Total Earned: $" + playerScore;
            Text scoreTextC = maxScoreText.GetComponent<Text>();
            scoreTextC.text = "Total Items: " + totalItems;
      }

      public void RestartGame(){
            playerScore = 0;
            caughtTrash = 0;
            caughtBig = 0;
            caughtMed = 0;
            caughtSmall = 0;
            totalTrash = 0;
            totalBig = 0;
            totalMed = 0;
            totalSmall = 0;
            totalItems = 0;
            SceneManager.LoadScene("Fishing Scene");
      }

      public void MainMenu(){
            SceneManager.LoadScene("Main Scene");
      }

      public void PauseMenu(){
            SceneManager.LoadScene("Pause Scene");
      }

      public void ResumeGame(){
            SceneManager.LoadScene("Fishing Scene");
      }

      public void endGame()
      {
            // Store the game results into GameData
            GameData.playerScore = playerScore;
            Debug.Log("Final Score: " + GameData.playerScore);
            GameData.caughtTrash = caughtTrash;
            GameData.caughtBig = caughtBig;
            GameData.caughtMed = caughtMed;
            GameData.caughtSmall = caughtSmall;
            GameData.totalTrash = totalTrash;
            GameData.totalBig = totalBig;
            GameData.totalMed = totalMed;
            GameData.totalSmall = totalSmall;
            GameData.totalItems = totalItems;

            SceneManager.LoadScene("Loss Scene");
      }

      

      public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}