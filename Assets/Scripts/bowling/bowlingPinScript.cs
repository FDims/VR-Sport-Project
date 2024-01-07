using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingPinScript : MonoBehaviour
{
    private bool pinDown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LowerFloor") || other.gameObject.CompareTag("MainFloor"))
        {
            pinDown = true;
        }
        else
        {
            pinDown = false;
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
