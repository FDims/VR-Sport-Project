
using UnityEditor.Timeline;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowTrigger : MonoBehaviour
{
    public bool isActivated = false; // Initial state of the button
    [SerializeField] GameObject thrower;
    [SerializeField] GameObject switchObject;
    [SerializeField] private float delayWindow = 5f;
    [SerializeField] TextMeshProUGUI timerText;

    private ThrowerController throwerController;
    private float timeDelay = 0f;

    void Start()
    {
        throwerController = thrower.GetComponent<ThrowerController>();
        isActivated = false;
        timeDelay = delayWindow;
    }
    private void Update()
    {
        timeDelay -= Time.deltaTime;
        timerText.text = timeDelay.ToString();
        if (isActivated && timeDelay<=0)
        {
            timeDelay = delayWindow;
            throwerController.ThrowBaseball();
        }
    }

    public void PressButton()
    {
        isActivated = !isActivated;
        if (isActivated)
        {
            switchObject.transform.Rotate(-60f, 0f, 0f, Space.Self);
        }
        else
        {
            switchObject.transform.Rotate(60f, 0f, 0f, Space.Self);
        }
    }




}
