using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameTimer gameTimer;

    private void Start()
    {
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
        // Reset the timer
        if (gameTimer != null)
        {
            gameTimer.ResetTimer();
        }

        // Resume time scale
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}