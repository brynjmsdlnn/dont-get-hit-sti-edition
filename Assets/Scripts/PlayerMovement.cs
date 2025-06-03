using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of movement
    [SerializeField] private float gridSize = 1f; // Size of each grid cell
    [SerializeField] private LayerMask obstacleLayer; // Layer for obstacles
    [SerializeField] public int lives = 3; // Add lives property (editable in Inspector)

    // Add this event to notify when game over occurs
    public UnityEvent OnGameOver;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Vector3 startingPosition; // Store the starting position

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // Store the initial position
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Smoothly move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if reached the target position
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
        else
        {
            // Continuous movement (optional: replace GetKeyDown with GetKey)
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                TryMove(Vector3.forward);
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                TryMove(Vector3.back);
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                TryMove(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                TryMove(Vector3.right);
        }
    }

    private void TryMove(Vector3 direction)
    {
        // Calculate the target position
        targetPosition = transform.position + direction * gridSize;

        // Check for obstacles using Raycast (or OverlapBox for broader checks)
        if (!Physics.Raycast(transform.position, direction, gridSize * 1.2f, obstacleLayer))
        {
            isMoving = true;
        }
        else
        {
            Debug.Log("Obstacle detected!"); // Optional: Log collisions for debugging
        }
    }

    // Detect collision with vehicles
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Vehicle"))
        {
            Debug.Log("Vehicle hit detected!");
            lives--;
            if (lives <= 0)
            {
                // Notify GameManager directly
                GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
                gameManager.GameOver();
                OnGameOver.Invoke();
            }
            else
            {
                ResetPosition();
            }
        }
    }

    // Reset the player's position to the starting position
    private void ResetPosition()
    {
        transform.position = startingPosition;
        isMoving = false; // Stop any ongoing movement
    }
}