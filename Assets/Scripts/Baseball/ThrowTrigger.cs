
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowTrigger : MonoBehaviour
{
    public Transform buttonVisual; // The visual component of the button (e.g., the button cap)
    public float buttonPressDistance = 0.05f; // Distance the button moves when pressed
    public bool isPressed = false; // Initial state of the button
    [SerializeField] GameObject thrower;

    private Vector3 initialButtonPosition;
    private XRGrabInteractable interactable;
    private ThrowerController throwerController;

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        throwerController = thrower.GetComponent<ThrowerController>();
        if (interactable != null)
        {
            interactable.onSelectEntered.AddListener(PressButton);
            interactable.onSelectExited.AddListener(ReleaseButton);
        }

        initialButtonPosition = buttonVisual.localPosition;
        UpdateVisual();
    }
    
    void PressButton(XRBaseInteractor interactor)
    {
        isPressed = true;
        UpdateVisual();
        throwerController.ThrowDelay();
        // Add actions when the button is pressed
    }

    void ReleaseButton(XRBaseInteractor interactor)
    {
        isPressed = false;
        UpdateVisual();
        // Add actions when the button is released
    }

    void UpdateVisual()
    {
        // Move the button visual component based on its pressed state
        if (isPressed)
        {
            buttonVisual.localPosition = initialButtonPosition - Vector3.up * buttonPressDistance;
        }
        else
        {
            buttonVisual.localPosition = initialButtonPosition;
        }

        // You can also trigger other actions or visuals based on the button state change
    }

}
