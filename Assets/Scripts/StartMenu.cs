using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject startMenuCanvas;
    [SerializeField] private GameObject characterSelectionPanel;

    void Start()
    {
        // Assign the button click event
        startButton.onClick.AddListener(OnStartButtonClicked);

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
}
