using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    [SerializeField] private GameObject RandTarget;
    
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private float[] areaPoint;
   
    public AudioClip hitSound;  

    private Vector3 spawnPosition;

     private ManagerGame manager;

    void Start()
    {
        // Find the ManagerGame script in the scene
        manager = FindObjectOfType<ManagerGame>();
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);

        if (collision.gameObject.CompareTag("Bullet"))
        {
            manager.TargetHit(100);
            int n = Random.Range(1,3);
            spawnPosition = spawnPoint[n].position;
            spawnPosition.x += Random.Range (-areaPoint[n], areaPoint[n]);
            spawnPosition.y += Random.Range (-areaPoint[n], areaPoint[n]);
            spawnPosition.z += Random.Range (-areaPoint[n], areaPoint[n]);
            
            // Handle the hit (e.g., despawn and respawn)
            Instantiate(RandTarget, spawnPosition, spawnPoint[n].rotation);
            Destroy(gameObject);
            

        }
    }
}
