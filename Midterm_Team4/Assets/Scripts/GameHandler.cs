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
      
      // public static class GameData
      // {
      //       public static int staticPlayerScore;
      //       public static int staticCaughtTrash;
      //       public static int staticCaughtBig;
      //       public static int staticCaughtMed;
      //       public static int staticCaughtSmall;
      //       public static int staticTotalTrash;
      //       public static int staticTotalBig;
      //       public static int staticTotalMed;
      //       public static int staticTotalSmall;
      //       public static int staticTotalItems;
      // }

      public static int playerScore = 0;
      public static int caughtTrash = 0;
      public static int caughtBig = 0;
      public static int caughtMed = 0;
      public static int caughtSmall = 0;
      public static int totalTrash = 0;
      public static int totalBig = 0;
      public static int totalMed = 0;
      public static int totalSmall = 0;
      public static int totalItems = 0;
 
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
            scoreTextB.text = "" + playerScore;
            Text scoreTextC = maxScoreText.GetComponent<Text>();
            scoreTextC.text = "" + totalItems;
      
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
            // int tempInt = playerScore;
            // GameData.staticPlayerScore = tempInt;
            // tempInt = caughtTrash;
            // GameData.staticCaughtTrash = tempInt;
            // tempInt = caughtBig;
            // GameData.staticCaughtBig = tempInt;
            // tempInt = caughtMed;
            // GameData.staticCaughtMed = tempInt;
            // tempInt = caughtSmall;
            // GameData.staticCaughtSmall = tempInt;
            // tempInt = totalTrash;
            // GameData.staticTotalTrash = tempInt;
            // tempInt = totalBig;
            // GameData.totalBig = tempInt;
            // tempInt = totalMed;
            // GameData.totalMed = tempInt;
            // tempInt = totalSmall;
            // GameData.totalSmall = tempInt;
            // tempInt = totalItems;
            // GameData.totalItems = tempInt;

            
            // Debug.Log("Final Score: " + GameData.staticPlayerScore);
      
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