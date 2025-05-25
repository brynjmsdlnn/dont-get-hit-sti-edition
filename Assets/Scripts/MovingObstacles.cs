using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.25f;
    [SerializeField] private bool moveRight = true; // Toggle direction in the Inspector
    private Transform thisTransform;
    private const float BOUNDARY = 20f;

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
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        Vector3 curPos = thisTransform.localPosition;
        float direction = moveRight ? 1 : -1; // Determine direction
        float newX = curPos.x + moveSpeed * Time.deltaTime * direction;

        // Handle boundary checks based on direction
        if (moveRight && newX > BOUNDARY)
        {
            newX = -BOUNDARY;
        }
        else if (!moveRight && newX < -BOUNDARY)
        {
            newX = BOUNDARY;
        }

        thisTransform.localPosition = new Vector3(newX, curPos.y, curPos.z);
    }
}
