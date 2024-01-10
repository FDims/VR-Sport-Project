using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingPinScript : MonoBehaviour
{
    public bool pinDown = false;

    public void destroyPin()
    {
        pinStatus();
        if(pinDown)
        {
            Destroy(gameObject);
        }
    }
    public void pinStatus()
    {
        float angle = Vector3.Angle(Vector3.up, transform.up);
        if (angle>= 20f)
            pinDown = true;
    }
}
