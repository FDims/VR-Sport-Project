using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : XRGrabInteractable
{
    public GameObject bulletPrefab;
    public Transform barrelTransform;
    public float bulletSpeed = 10f;
    public AudioClip shootSound;

    
    
    public void Shoot()
    {
         // Play the shoot sound effect
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        
        // Instantiate a bullet at the barrel position and rotation
        GameObject bullet = Instantiate(bulletPrefab, barrelTransform.position, barrelTransform.rotation);

        // Get the Rigidbody component of the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (bulletRigidbody != null)
        {
            // Set the velocity of the bullet to move in the forward direction of the barrel
            bulletRigidbody.velocity = barrelTransform.forward * bulletSpeed;
        }
    }
}
