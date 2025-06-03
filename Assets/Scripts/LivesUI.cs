using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for Image component

public class LivesUI : MonoBehaviour
{
    [SerializeField] public PlayerMovement player;
    [SerializeField] private Image[] heartImages; // Array of Image components for hearts
    [SerializeField] private Sprite fullHeartSprite; // Sprite for full heart
    [SerializeField] private Sprite depletedHeartSprite; // Sprite for depleted heart

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<PlayerMovement>();
        }
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            UpdateHearts();
            if (player.lives <= 0)
            {
                FindFirstObjectByType<GameManager>().GameOver();
            }
        }
    }

    // Update the heart sprites based on player's lives
    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (heartImages[i] == null) continue;

            if (i < player.lives)
            {
                heartImages[i].sprite = fullHeartSprite;
            }
            else
            {
                heartImages[i].sprite = depletedHeartSprite;
            }
        }
    }
}
