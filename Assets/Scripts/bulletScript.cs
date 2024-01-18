using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Target")){
            Destroy(gameObject);
        }
    }
}
