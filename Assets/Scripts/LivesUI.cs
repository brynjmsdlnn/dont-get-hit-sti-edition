using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        if (livesText == null)
        {
            livesText = GetComponent<TMP_Text>();
        }
        if (player == null)
        {
            player = FindFirstObjectByType<PlayerMovement>();
            Debug.Log(player ? "Found player automatically" : "No player found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            livesText.text = $"Lives: {player.lives}";

            // Extra safety check
            if (player.lives <= 0)
            {
                FindFirstObjectByType<GameManager>().GameOver();
            }
        }
    }
}
