using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject ControllerGuide = null;
    [SerializeField] private GameObject Tutorial_1 = null;
    [SerializeField] private GameObject Tutorial_2 = null;

    private void OnEnable()
    {
        // Subscribe to click events on each tutorial pop-up
        AddClickListener(ControllerGuide, ChangeC2T1);
        AddClickListener(Tutorial_1, ChangeT12T2);
        AddClickListener(Tutorial_2, RemoveT2);
    }

    private void OnDisable()
    {
        // Unsubscribe from click events on each tutorial pop-up
        RemoveClickListener(ControllerGuide, ChangeC2T1);
        RemoveClickListener(Tutorial_1, ChangeT12T2);
        RemoveClickListener(Tutorial_2, RemoveT2);
    }

    private void AddClickListener(GameObject obj, UnityAction<XRBaseInteractor> action)
    {
        var interactable = obj.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.onActivate.AddListener(action);
        }
    }

    private void RemoveClickListener(GameObject obj, UnityAction<XRBaseInteractor> action)
    {
        var interactable = obj.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.onActivate.RemoveListener(action);
        }
    }

    public void ChangeC2T1(XRBaseInteractor interactor)
    {
        ControllerGuide.SetActive(false);
        ActivatePopUp(Tutorial_1);
    }

    public void ChangeT12T2(XRBaseInteractor interactor)
    {
        Tutorial_1.SetActive(false);
        ActivatePopUp(Tutorial_2);
    }

    public void RemoveT2(XRBaseInteractor interactor)
    {
        Tutorial_2.SetActive(false);
    }

    public void ActivatePopUp(GameObject PopUp)
    {
        PopUp.SetActive(true);
    }
}
