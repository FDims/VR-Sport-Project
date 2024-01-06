using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    [SerializeField] private GameObject RandTarget; // Reference to the target prefab
    public Vector3 initialSpawnPosition = new Vector3(0f, 0f, 0f);
    public float spawnRadius = 5f; // Radius within which the targets will spawn

    private GameObject currentTarget;

    public void Start()
    {
        DeactivateSpawnTarget();
    }

    public void SpawnTarget()
    {
        DeactivateSpawnTarget();
        // Generate a random offset within the specified spawn radius
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        // randomOffset.y = 0; // Ensure targets spawn on the same level

        // Calculate the new spawn position by adding the offset to the initial spawn position
        Vector3 newSpawnPosition = initialSpawnPosition + randomOffset;

        // Spawn a new target at the calculated position
        currentTarget = Instantiate(RandTarget, newSpawnPosition, Quaternion.identity);

        RandTarget.SetActive(true);
    }

    public void DeactivateSpawnTarget(){
        RandTarget.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the target
        if (other.gameObject == currentTarget)
        {
            // Destroy the current target
            Destroy(currentTarget);

            // Spawn a new target after a short delay (you can customize this delay)
            Invoke("SpawnTarget", 2f);
        }
    }
}

