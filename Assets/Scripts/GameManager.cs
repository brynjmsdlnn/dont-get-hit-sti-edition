using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject characterSelectionPanel;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private LivesUI livesUI;

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
            gameTimer = FindFirstObjectByType<GameTimer>();
        }

        // Find LivesUI if not assigned
        if (livesUI == null)
        {
            livesUI = FindFirstObjectByType<LivesUI>();
        }

        // Ensure timer and lives UI are hidden at start
        if (gameTimer != null)
        {
            gameTimer.gameObject.SetActive(false);
            gameTimer.StopTimer();
            gameTimer.ResetTimer();
        }

        if (livesUI != null)
        {
            livesUI.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        // Show and start the timer
        if (gameTimer != null)
        {
            gameTimer.gameObject.SetActive(true);
            gameTimer.StartTimer();
        }

        // Show lives UI
        if (livesUI != null)
        {
            livesUI.gameObject.SetActive(true);
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

        // Show character selection panel again
        if (characterSelectionPanel != null)
        {
            characterSelectionPanel.SetActive(true);
            // This will trigger OnEnable which will show and reset the preview models
        }

        // Hide game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}