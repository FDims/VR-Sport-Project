using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
       // public int scoreValue = 100; // Score value for hitting the target

        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Handle the hit (e.g., despawn and respawn).
            Destroy(gameObject);
            FindObjectOfType<TargetSpawner>().SpawnTarget();

            // Increase the score
            // ScoreManager.Instance.AddScore(scoreValue);

        }
    }
}
