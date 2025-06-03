using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelection : MonoBehaviour
{
    private GameObject boyPrefab;
    private GameObject girlPrefab;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject boyPreviewModel;
    [SerializeField] private GameObject girlPreviewModel;

    void Awake()
    {
        // Initialize models
        boyPreviewModel.SetActive(false);
        girlPreviewModel.SetActive(false);
    }

    public void SelectCharacter(GameObject characterPrefab)
    {
        Time.timeScale = 1f;

        Vector3 spawnPosition = characterPrefab == boyPrefab ?
            new Vector3(0.5f, -0.3f, -45f) :
            new Vector3(0.5f, 0.16f, -45f);

        GameObject player = Instantiate(characterPrefab, spawnPosition, Quaternion.Euler(0, 90f, 0));

        // Update camera follow
        if (Camera.main.TryGetComponent(out CameraFollow cameraFollow))
            cameraFollow.target = player.transform;

        // Update LivesUI
        if (FindFirstObjectByType<LivesUI>() is LivesUI livesUI)
            livesUI.player = player.GetComponent<PlayerMovement>();

        gameObject.SetActive(false);
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.StartGame();
    }

    void OnEnable()
    {
        cameraController.SetPreviewState();
        boyPreviewModel.SetActive(true);
        girlPreviewModel.SetActive(true);
    }

    void OnDisable()
    {
        cameraController.SetGameplayState();
        boyPreviewModel.SetActive(false);
        girlPreviewModel.SetActive(false);
    }
}
