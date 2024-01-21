using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;


public class TutorialScript : MonoBehaviour
{   
    [SerializeField] private GameObject ControllerGuide = null;
    [SerializeField] private GameObject Tutorial_1 = null;


    public void Start()
    {
        ActivatePopUp();
    }
    public void DeactivateController()
    {
        ControllerGuide.SetActive(false);
    }
     public void DeactivateTutorial()
    {
        Tutorial_1.SetActive(false);
    }
    public void ActivatePopUp()
    {
        ControllerGuide.SetActive(false);

        ControllerGuide.SetActive(true);
    }
    
}

