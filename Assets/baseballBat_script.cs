using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseballBat_script : MonoBehaviour
{
    [SerializeField] private AudioSource batDrop;
    [SerializeField] private AudioSource batHit;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            batHit.Play();
        }
        else
        {
            batDrop.Play();
        }
    }
}
