using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private GameObject boyPrefab;
    private GameObject girlPrefab;
    [SerializeField] private Button boyButton;
    [SerializeField] private Button girlButton;

    // Start is called before the first frame update
    void Awake()
    {
        boyPrefab = Resources.Load<GameObject>("Boy Player");
        girlPrefab = Resources.Load<GameObject>("Girl Player");

        // Add error handling
        if (boyPrefab == null) Debug.LogError("Boy Player prefab not found at 'Boy Player'");
        if (girlPrefab == null) Debug.LogError("Girl Player prefab not found at 'Girl Player'");
    }

    // Start is called before the first frame update
    void Start()
    {
        boyButton.onClick.AddListener(() => SelectCharacter(boyPrefab));
        girlButton.onClick.AddListener(() => SelectCharacter(girlPrefab));
    }

    private void SelectCharacter(GameObject characterPrefab)
    {
        // Ensure timescale is normal before spawning
        Time.timeScale = 1f;

        Vector3 boySpawnPosition = new Vector3(0.5f, -0.3f, -45f);
        Vector3 girlSpawnPosition = new Vector3(0.5f, 0.16f, -45f);
        Vector3 spawnPosition = characterPrefab == boyPrefab ? boySpawnPosition : girlSpawnPosition;
        Quaternion spawnRotation = Quaternion.Euler(0, 90f, 0);
        GameObject player = Instantiate(characterPrefab, spawnPosition, spawnRotation);

        // Update camera follow
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null) cameraFollow.target = player.transform;

        // Update LivesUI reference
        LivesUI livesUI = FindObjectOfType<LivesUI>();
        if (livesUI != null) livesUI.player = player.GetComponent<PlayerMovement>();
        else Debug.LogWarning("LivesUI not found in scene");

        Debug.Log($"Main camera: {Camera.main}");
        Debug.Log($"CameraFollow: {Camera.main.GetComponent<CameraFollow>()}");
        Debug.Log($"Player spawned: {player}");

        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
