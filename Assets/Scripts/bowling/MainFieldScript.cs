using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainFieldScript : MonoBehaviour
{
    GameObject[] balls;
    private void Start()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }
    private void Update()
    {
            balls = GameObject.FindGameObjectsWithTag("Ball");
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            for(int i = 0; i < balls.Length; i++)
            {
                XRGrabInteractable toDisable = balls[i].GetComponent<XRGrabInteractable>();
                if(toDisable != null)
                {
                    toDisable.enabled = false;
                }
            }
        }
    }
}
