using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the obstacle horizontally between boundaries. Direction can be toggled.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.25f;
    [SerializeField] private bool moveRight = true; // Toggle direction in the Inspector
    [SerializeField] private float boundary = 20f; // Replace the const with a serialized field
    [SerializeField] private float loopDelay = 0f; // Delay in seconds before resetting
    private Rigidbody rb;
    private bool isDelaying = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
#if UNITY_EDITOR
        Debug.Log($"my name is {gameObject.name} and my position is {rb.position}");
#endif
    }

    private void FixedUpdate() // Use FixedUpdate for physics
    {
        if (!isDelaying)
        {
            MoveObstacle();
        }
    }

    private void MoveObstacle()
    {
        float direction = moveRight ? 1 : -1;
        Vector3 velocity = new Vector3(moveSpeed * direction, 0, 0);
        rb.velocity = velocity; // Move via Rigidbody

        // Boundary check
        if ((moveRight && rb.position.x > boundary) || (!moveRight && rb.position.x < -boundary))
        {
            StartCoroutine(DelayBeforeReset());
        }
    }

    private IEnumerator DelayBeforeReset()
    {
        isDelaying = true;
        yield return new WaitForSeconds(loopDelay);
        ResetPosition();
        isDelaying = false;
    }

    public void ResetPosition()
    {
        rb.position = new Vector3(
            moveRight ? -boundary : boundary,
            rb.position.y,
            rb.position.z
        );
    }
}
