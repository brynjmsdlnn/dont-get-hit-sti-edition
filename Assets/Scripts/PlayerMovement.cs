using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of movement
    [SerializeField] private float gridSize = 1f; // Size of each grid cell
    [SerializeField] private LayerMask obstacleLayer; // Layer for obstacles

    private bool isMoving = false;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {

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
        if (!Physics.Raycast(transform.position, direction, gridSize * 1.1f, obstacleLayer))
        {
            isMoving = true;
        }
        else
        {
            Debug.Log("Obstacle detected!"); // Optional: Log collisions for debugging
        }
    }
}
