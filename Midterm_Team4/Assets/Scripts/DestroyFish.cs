using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyFish : MonoBehaviour
{
    public GameHandler gameHandlerObj;

    void Start(){
          if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
          }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        //gameObject.GetComponent<AudioSource>().Play();
        gameHandlerObj.AddScore(1);
    }
}



