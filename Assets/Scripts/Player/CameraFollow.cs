using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target that the camera should follow
    public Vector3 offset;   // Offset between the camera and the target
    public float smoothSpeed = 0.125f; // Speed of the camera movement

    private float fixedZ = 10f;    
    void Start()
    {
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, fixedZ) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
