using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Handle the hit (e.g., despawn and respawn).
            Destroy(gameObject);
            FindObjectOfType<TargetSpawner>().SpawnTarget();
        }
    }
}
