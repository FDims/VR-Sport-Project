using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{   
    [SerializeField] private GameObject ControllerGuide = null;
    [SerializeField] private GameObject Tutorial_1 = null;
    [SerializeField] private GameObject Tutorial_2 = null;
  
  
    
    public void ChangeC2T1(){
        ControllerGuide.SetActive(false);
        ActivatePopUp(Tutorial_1);
    }

    public void ChangeT12T2(){
        Tutorial_1.SetActive(false);
        ActivatePopUp(Tutorial_2);
    }
    public void RemoveT2(){
        Tutorial_2.SetActive(false);
    }

    public void ActivatePopUp(GameObject PopUp) {
    
        PopUp.SetActive(true);
    }

}
