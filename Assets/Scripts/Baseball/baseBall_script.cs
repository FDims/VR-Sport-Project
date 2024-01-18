using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBall_script : MonoBehaviour
{
    [SerializeField] private AudioSource ballHit;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bat")
        {
            ballHit.Play();
        }
    }
}
