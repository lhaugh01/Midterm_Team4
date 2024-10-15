using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LossSceneHandler : MonoBehaviour
{
    public Text smallFishText;
    public Text medFishText;
    public Text bigFishText;
    public Text trashFishText;
    public Text scoreText;
    public Text totalItemsText;

    void Start()
    {
        // Retrieve and display the data from GameData
        smallFishText.text = GameHandler.caughtSmall + "/" +
                            GameHandler.totalSmall;
        Debug.Log(GameHandler.caughtSmall + "/" + GameHandler.totalSmall);
        medFishText.text = GameHandler.caughtMed + "/" + GameHandler.totalMed;
        bigFishText.text = GameHandler.caughtBig + "/" + GameHandler.totalBig;
        trashFishText.text = GameHandler.caughtTrash + "/" +
                                GameHandler.totalTrash;
        scoreText.text = "Total Earned: $" + GameHandler.playerScore;
        totalItemsText.text = "Total Items: " + GameHandler.totalItems;
    }
}
