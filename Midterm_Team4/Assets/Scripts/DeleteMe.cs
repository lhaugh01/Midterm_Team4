using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour{

    public float delayTime = 0.5f;
    public GameHandler gameHandlerObj;

    void Start(){
        StartCoroutine(DeleteThisDelay());
        if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
          }
    }


    IEnumerator DeleteThisDelay(){
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
}
