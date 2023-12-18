using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    [SerializeField] GameObject gameController;
    private BowlingController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = gameController.GetComponent<BowlingController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            gameControllerScript.addThrow();
        }
    }
}
