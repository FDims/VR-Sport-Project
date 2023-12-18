using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingController : MonoBehaviour
{
    [SerializeField] GameObject traySpawnPoint;
    [SerializeField] GameObject PinSetPrefab;
    [SerializeField] GameObject BallPrefab;
    [SerializeField] GameObject slider;
    public float sliderSpeed = 1f;

    private float throwCount = 0f;
    private GameObject Pinset;
    private GameObject[] Pins;
    private GameObject[] balls;
    private bool slideUp = false;
    private bool slideDown = false;
    // Start is called before the first frame update
    void Start()
    {
        slideUp = false;
        slideDown = false;
    }
    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length < 4)
        {
            initBall();
        }

        if (slideDown)
        {
            sliderDown();
        }
        if(slideUp)
        {
            sliderUp();
        }
    }
    public void addThrow()
    {
        bowlingRoutine();
    }
    public void bowlingRoutine()
    {
        slideDown = true;
        if (throwCount>=2) {
            Invoke("restart", 3);
            throwCount = 0;
        }
        else
        {
            throwCount++;
            Invoke("pinCheck", 3);
        }
        for (int i = 0; i < balls.Length; i++)
        {
            XRGrabInteractable toEnable = balls[i].GetComponent<XRGrabInteractable>();
            if (toEnable != null)
            {
                toEnable.enabled = true;
            }
        }
        slideUp = true;
    }

    //Routine After Throw
    public void restart()
    {
        throwCount = 0f;
        Pinset = GameObject.FindGameObjectWithTag("BowlingPinSet");
        Destroy(Pinset);
        initPIn();
    }

    public void pinCheck()
    {
        Pins = GameObject.FindGameObjectsWithTag("BownlingPin");
        for(int i = 0; i < Pins.Length; i++)
        {
            bowlingPinScript pinScript = Pins[i].GetComponent<bowlingPinScript>();
            if (pinScript != null) 
            {
                pinScript.destroyPin();
            }
        }
    }

    //init Props
    public void initPIn()
    {
        Instantiate(PinSetPrefab);
    }
    public void initBall()
    {
        Instantiate(BallPrefab,traySpawnPoint.transform.position, Quaternion.identity);
    }


    //slider move
    public void sliderDown()
    {
        Vector3 goal = new Vector3(9.38f, 0f, 2.08f);
        float dist = Vector3.Distance(transform.position, goal);
        if (dist > 0f)
        {
            slider.transform.position = Vector3.MoveTowards(slider.transform.position, goal, sliderSpeed * Time.deltaTime);
        }
        else
        {
            slideDown=false;
        }
    }
    public void sliderUp()
    {
        Vector3 goal = new Vector3(9.38f, 2.04f, 2.08f);
        float dist = Vector3.Distance(transform.position, goal);
        if (dist > 0f)
        {
            slider.transform.position = Vector3.MoveTowards(slider.transform.position, goal, sliderSpeed * Time.deltaTime);
        }
        else
        {
            slideUp=false;
        }
    }
}
