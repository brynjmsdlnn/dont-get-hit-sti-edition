using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton; // Add this field
    [SerializeField] private GameObject startMenuCanvas;
    [SerializeField] private GameObject characterSelectionPanel;

    void Start()
    {
        // Assign the button click events
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked); // Add this line

        // Ensure the character selection panel is hidden at start
        if (characterSelectionPanel != null)
            characterSelectionPanel.SetActive(false);
    }

    private void OnStartButtonClicked()
    {
        // Hide the start menu
        startMenuCanvas.SetActive(false);

        // Show the character selection panel
        if (characterSelectionPanel != null)
            characterSelectionPanel.SetActive(true);
    }

    private void OnExitButtonClicked()
    {
        // Quit the application
        Application.Quit();

        // For testing in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}