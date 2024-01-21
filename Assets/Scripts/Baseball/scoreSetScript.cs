using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class scoreSetScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) {
            scoreText.text = Score.ToString();
            other.gameObject.tag = "Untagged";
        }
    }
}
