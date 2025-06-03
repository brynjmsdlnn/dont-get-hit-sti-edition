using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject characterSelectionPanel;
    [SerializeField] private GameTimer gameTimer;

    private void Start()
    {
        // Show character selection at start
        if (characterSelectionPanel != null)
        {
            characterSelectionPanel.SetActive(true);
        }

        // Ensure game over panel is hidden at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Find the timer if not assigned
        if (gameTimer == null)
        {
            gameTimer = FindObjectOfType<GameTimer>();
        }

        // Ensure timer is stopped at start
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
            gameTimer.ResetTimer();
        }
    }

    public void StartGame()
    {
        // Start the timer
        if (gameTimer != null)
        {
            gameTimer.StartTimer();
        }
    }

    public void GameOver()
    {
        // Show game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Stop the timer
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
        }

        // Optional: Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Reset timescale FIRST
        Time.timeScale = 1f;

        // Reset the timer
        if (gameTimer != null)
        {
            gameTimer.ResetTimer();
        }

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}