using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        if (livesText == null)
        {
            livesText = GetComponent<TMP_Text>();
        }
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"Lives: {player.lives}";
    }
}
