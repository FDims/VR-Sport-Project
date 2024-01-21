using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BowlingBallScript : MonoBehaviour
{
    [SerializeField] AudioSource slideFx;
    [SerializeField] AudioSource hitFx;
    private Rigidbody rb;
    public Vector3 additionalVelocity = new Vector3(5f, 0f, 0f); // Additional velocity to be added

    private float startHit = 2.7f;
    private void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainFloor") || collision.gameObject.CompareTag("BowlingSideField"))
        {
            if (rb.velocity.magnitude <= 3f)
            {
                rb.velocity += additionalVelocity;
            }
        }
        if (collision.gameObject.CompareTag("MainFloor"))
        {
            slideFx.Play();
        }
        if (collision.gameObject.CompareTag("BowlingPin"))
        {
            hitFx.time = startHit;
            hitFx.Play();
        }
    }


}
