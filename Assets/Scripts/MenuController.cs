using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject BaseballPopUp = null;
    [SerializeField] private GameObject BowlingPopUp = null;

     public void Start() {
        DeactivatePopUp();
     }
    
    public void ActivatePopUp(GameObject PopUp) {
        DeactivatePopUp();

        PopUp.SetActive(true);
    }

    public void DeactivatePopUp(){
        BaseballPopUp.SetActive(false);
        BowlingPopUp.SetActive(false);

    }

    public void SceneLoader(int SceneNumber){
        SceneManager.LoadScene(SceneNumber);
    }

}
