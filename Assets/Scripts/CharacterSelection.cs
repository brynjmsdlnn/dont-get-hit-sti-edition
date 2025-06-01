using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private Button cubeButton;
    [SerializeField] private Button sphereButton;

    // Start is called before the first frame update
    void Start()
    {
        cubeButton.onClick.AddListener(() => SelectCharacter(cubePrefab));
        sphereButton.onClick.AddListener(() => SelectCharacter(spherePrefab));
    }

    private void SelectCharacter(GameObject characterPrefab)
    {
        // Ensure timescale is normal before spawning
        Time.timeScale = 1f;

        Vector3 spawnPosition = new Vector3(0.5f, 0.5f, -42.48f);
        GameObject player = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

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
