using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;      // UI Text to display the timer
    [SerializeField] private TextMeshProUGUI scoreText;      // UI Text to display the total score
    public float gameTime = 30f; // Total game time in seconds
    private float timer;         // Current timer value
    private bool gameActive;     // Flag to indicate if the game is active
    private int totalScore;      // Total score accumulated during the game
    [SerializeField] private GameObject RandTarget = null;  // Corrected variable name
     private  Vector3 targetSpawnPosition = new Vector3(-3.9f, 1.33f, 0.43f);

    public void Start()
    {
        DeactivateTarget();
        // Initialize the UI
        timerText.text = "Time: " + gameTime.ToString("F1");
        scoreText.text = "Score: 0";
    }

     public void ActivateTarget(GameObject Target) {
        DeactivateTarget();

         // Check if there's already a target in the scene
    if (RandTarget == null)
    {
        // Instantiate a new target or activate a pre-existing one
        RandTarget = Instantiate(RandTarget, targetSpawnPosition, Quaternion.identity);
    }

        Target.SetActive(true);
    }
        public void DeactivateTarget(){
        RandTarget.SetActive(false);
        
    }

    public void Update()
    {
        // Update the timer if the game is active
        if (gameActive)
        {
            timer -= Time.deltaTime;

            // Check if the timer has reached zero
            if (timer <= 0f)
            {
                gameActive = false;
                timer = 0f;
                // Optionally, you can perform end-of-game actions here
                DisplayEndGame();
            }

            // Update the UI
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
        ActivateTarget(RandTarget);
    }

    public void DisplayEndGame()
{
    // Display the final score
    scoreText.text = "Total Score: " + totalScore;

    // Find and destroy all GameObjects with the tag "YourTargetTag"
    GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

    foreach (GameObject target in targets)
    {
        Destroy(target);
    }
}


    // This method is called when a target is hit (assuming your Target script calls this method)
    public void TargetHit(int points)
    {
        // Update the total score
        totalScore += points;

        // Update the UI
        scoreText.text = "Score: " + totalScore;
    }

}
