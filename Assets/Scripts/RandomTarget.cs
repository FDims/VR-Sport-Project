using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    [SerializeField] private GameObject RandTarget;
    
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnAreaSize;
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
            spawnPosition = spawnPoint.position;
            spawnPosition.x += Random.Range (-spawnAreaSize, spawnAreaSize);
            spawnPosition.y += Random.Range (-spawnAreaSize/2, spawnAreaSize/2);
            spawnPosition.z += Random.Range (-spawnAreaSize, spawnAreaSize);
            
            // Handle the hit (e.g., despawn and respawn)
            Instantiate(RandTarget, spawnPosition, spawnPoint.rotation);
            Destroy(gameObject);
            

        }
    }
}
