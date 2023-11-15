using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowerController : MonoBehaviour
{

    [SerializeField] private Transform launchPoint; // Point where the baseball will be launched from
    [SerializeField] private Rigidbody baseballPrefab; // Prefab of the baseball object
    [SerializeField] private float throwForce = 10f; // Force applied to the baseball
    [SerializeField] private GameObject target;


    public void ThrowDelay(){
        Invoke("ThrowBaseball", 3f);
    }
    void ThrowBaseball()
    {
        Rigidbody baseballInstance = Instantiate(baseballPrefab, launchPoint.position, launchPoint.rotation);
        baseballInstance.AddForce((target.transform.position-launchPoint.position) * throwForce, ForceMode.Impulse);
    }
}
