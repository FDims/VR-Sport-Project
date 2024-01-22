using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBall_script : MonoBehaviour
{
    [SerializeField] private AudioSource ballHit;

    private void Update()
    {
        if (gameObject.tag == "Untagged")
        {
            Invoke("deleteBall", 4);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bat")
        {
            ballHit.Play();
        }
    }

    private void deleteBall()
    {
        Destroy(gameObject);
    }
}
