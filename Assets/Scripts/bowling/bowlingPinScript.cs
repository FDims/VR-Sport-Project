using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingPinScript : MonoBehaviour
{
    private bool pinDown = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "LowerFloor"|| collision.gameObject.tag == "MainFloor")
        {
            pinDown = true;
        }
        else
        {
            pinDown=false;
        }
    }
    public void destroyPin()
    {
        if(pinDown)
        {
            Destroy(gameObject);
        }
    }

}
