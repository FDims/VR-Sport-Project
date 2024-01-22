
using UnityEditor.Timeline;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowTrigger : MonoBehaviour
{
    [SerializeField] GameObject thrower;
    [SerializeField] GameObject switchObject;
    [SerializeField] private float delayWindow = 5f;
    [SerializeField] TextMeshProUGUI timerText;

    private bool isActivated = false; // Initial state of the button
    private ThrowerController throwerController;
    private float timeDelay = 0f;

    void Start()
    {
        throwerController = thrower.GetComponent<ThrowerController>();
        isActivated = false;
        timeDelay = delayWindow;
        timerText.text = timeDelay.ToString();
    }
    private void Update()
    {
        timeDelay -= Time.deltaTime;
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

    public void timerUp()
    {
        timeDelay += 1;
        timerText.text = timeDelay.ToString();
    }
    public void timerDown()
    {
        timeDelay -= 1;
        timerText.text = timeDelay.ToString();
    }




}
