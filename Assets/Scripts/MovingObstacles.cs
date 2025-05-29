using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the obstacle horizontally between boundaries. Direction can be toggled.
/// </summary>
[RequireComponent(typeof(Transform))]
public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.25f;
    [SerializeField] private bool moveRight = true; // Toggle direction in the Inspector
    [SerializeField] private float boundary = 20f; // Replace the const with a serialized field
    [SerializeField] private float loopDelay = 0f; // Delay in seconds before resetting
    private Transform thisTransform;
    private bool isDelaying = false;

    private void Awake()
    {
        thisTransform = transform; // 'transform' is cached for efficiency
    }

    private void Start()
    {
#if UNITY_EDITOR
        Debug.Log($"my name is {gameObject.name} and my position is {thisTransform.localPosition}");
#endif
    }

    private void Update()
    {
        if (!isDelaying)
        {
            MoveObstacle();
        }
    }

    private void MoveObstacle()
    {
        Vector3 curPos = thisTransform.localPosition;
        float direction = moveRight ? 1 : -1; // Determine direction
        float newX = curPos.x + moveSpeed * Time.deltaTime * direction;

        // Handle boundary checks based on direction
        if (moveRight && newX > boundary)
        {
            StartCoroutine(DelayBeforeReset());
        }
        else if (!moveRight && newX < -boundary)
        {
            StartCoroutine(DelayBeforeReset());
        }
        else
        {
            thisTransform.localPosition = new Vector3(newX, curPos.y, curPos.z);
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
        thisTransform.localPosition = new Vector3(moveRight ? -boundary : boundary,
                                                 thisTransform.localPosition.y,
                                                 thisTransform.localPosition.z);
    }
}
