using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-0.5f, 11f, -17f); // Match your scene's values

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}
