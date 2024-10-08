using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour{

    public float delayTime = 0.5f;

    void Start(){
        StartCoroutine(DeleteThisDelay());
    }


    IEnumerator DeleteThisDelay(){
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
}
