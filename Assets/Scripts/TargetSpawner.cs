using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
  [SerializeField] private GameObject RandTarget = null;
   

     public void Start() {
        DeactivateTarget();
     }
    
    public void ActivateTarget(GameObject RandTarget) {
        DeactivateTarget();

        RandTarget.SetActive(true);
    }

    public void DeactivateTarget(){
        RandTarget.SetActive(false);
        
    }
}