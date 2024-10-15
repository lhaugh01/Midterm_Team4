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
        smallFishText.text = GameData.caughtSmall + "/" + GameData.totalSmall;
        Debug.Log(GameData.caughtSmall + "/" + GameData.totalSmall);
        medFishText.text = GameData.caughtMed + "/" + GameData.totalMed;
        bigFishText.text = GameData.caughtBig + "/" + GameData.totalBig;
        trashFishText.text = GameData.caughtTrash + "/" + GameData.totalTrash;
        scoreText.text = "Total Earned: $" + GameData.playerScore;
        totalItemsText.text = "Total Items: " + GameData.totalItems;
    }
}
