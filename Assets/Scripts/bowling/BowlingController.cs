using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingController : MonoBehaviour
{
    [SerializeField] GameObject traySpawnPoint;
    [SerializeField] GameObject PinSetPrefab;
    [SerializeField] GameObject BallPrefab;
    [SerializeField] GameObject slider;
    [SerializeField] TextMeshProUGUI[] scoreText;
    public float sliderSpeed = 1f;

    private int throwCount = 0;
    private GameObject Pinset;
    private GameObject[] Pins;
    private GameObject[] balls;
    private float[] score;
    private bool slideUp = false;
    private bool slideDown = false;
    // Start is called before the first frame update
    void Start()
    {
        score = new float[] { 0, 0 };
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
        throwCount++;
        bowlingRoutine();
    }
    public void bowlingRoutine()
    {
        slideDown = true;
        if (throwCount>=2) {
            Invoke("pinCheck", 2);
            Invoke("restart",3);
        }
        else
        { 
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
    }

    //Routine After Throw
    public void restart()
    {
        throwCount = 0;
        Pinset = GameObject.FindGameObjectWithTag("BowlingPinSet");
        Destroy(Pinset);
        initPIn();
        score = new float[] { 0, 0 };
        slideDown = false;
        slideUp = true;
    }

    public void pinCheck()
    {
        Pins = GameObject.FindGameObjectsWithTag("BowlingPin");
        scoreText[throwCount - 1].text = "0";
        for (int i = 0; i < Pins.Length; i++)
        {
            bowlingPinScript pinScript = Pins[i].GetComponent<bowlingPinScript>();
            if (pinScript != null) 
            {
                pinScript.destroyPin();
                if(pinScript.pinDown)
                    score[throwCount - 1]++;
            }
        }
        scoreText[throwCount - 1].text= score[throwCount - 1].ToString();
        if (throwCount == 1)
            scoreText[1].text = "0";
        if (throwCount == 1 && score[0] == 10)
            restart();
        else
        {
            slideDown = false;
            slideUp = true;
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
        slider.transform.position = Vector3.MoveTowards(slider.transform.position, goal, sliderSpeed * Time.deltaTime);
        if(slider.transform.position == goal)
        {
            slideDown = false;
        }
    }
    public void sliderUp()
    {
        Vector3 goal = new Vector3(9.38f, 2.04f, 2.08f);
        slider.transform.position = Vector3.MoveTowards(slider.transform.position, goal, sliderSpeed * Time.deltaTime);
        if (slider.transform.position == goal)
        {
            slideUp = false;
        }
    }
}
