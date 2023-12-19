using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject ConfPopUp = null;
   

     public void Start() {
        DeactivatePopUp();
     }
    
    public void ActivatePopUp(GameObject PopUp) {
        DeactivatePopUp();

        PopUp.SetActive(true);
    }

    public void DeactivatePopUp(){
        ConfPopUp.SetActive(false);
        
    }

    public void SceneLoader(int SceneNumber){
        SceneManager.LoadScene(SceneNumber);
    }

}
