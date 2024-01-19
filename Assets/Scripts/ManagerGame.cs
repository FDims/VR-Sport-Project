using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public float gameTime = 30f;
    private float timer;
    private bool gameActive;
    private int totalScore;
    [SerializeField] private Transform spawnPoint;
    private Vector3 targetSpawnPosition = new Vector3(-3.9f, 1.33f, 0.43f);

    // Declare the prefab to be used
    [SerializeField] private GameObject randTargetPrefab = null;

    private GameObject randTarget;

    public void Start()
    {
        DeactivateTarget();
        timerText.text = "Time: " + gameTime.ToString("F1");
        scoreText.text = "Score: 0";
    }

    public void ActivateTarget(GameObject targetPrefab)
    {
        DeactivateTarget();

        // Check if there's already a target in the scene
        if (randTarget == null)
        {
            Vector3 spawnPoint2 = new Vector3 (targetSpawnPosition.x-2,targetSpawnPosition.y,targetSpawnPosition.z);
            // Instantiate a new target or activate a pre-existing one
            randTarget = Instantiate(targetPrefab, targetSpawnPosition, spawnPoint.rotation);
            randTarget = Instantiate(targetPrefab, spawnPoint2, spawnPoint.rotation);
        }

        randTarget.SetActive(true);
    }

    public void DeactivateTarget()
    {
        if (randTarget != null)
        {
            randTarget.SetActive(false);
        }
    }

    public void Update()
    {
        if (gameActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                gameActive = false;
                timer = 0f;
                DisplayEndGame();
            }

            timerText.text = "Time: " + timer.ToString("F1");
        }
    }

    public void StartGame()
    {
        // Reset the timer and total score
        timer = gameTime;
        totalScore = 0;
        scoreText.text = "Score: 0";

        // Set gameActive to true to start the timer
        gameActive = true;

        // Optionally, you can perform start-of-game actions here
        ActivateTarget(randTargetPrefab);
    }

    public void DisplayEndGame()
{
    scoreText.text = "Total Score: " + totalScore;

    // Find all GameObjects with the tag "YourTargetTag"
    GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

    foreach (GameObject target in targets)
    {
        Destroy(target);
    }
}

  public void TargetHit(int points)
{
    // Update the total score
    totalScore += points;
    scoreText.text = "Score: " + totalScore;

} 

}