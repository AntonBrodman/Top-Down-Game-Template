using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target that the camera should follow
    public Vector3 offset;   // Offset between the camera and the target
    public float smoothSpeed = 0.125f; // Speed of the camera movement

    private float fixedZ = 10f;    // The fixed Z position of the camera

    void Start()
    {
        // Store the initial Z position of the camera
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        // Compute the desired position (excluding the Z axis)
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, fixedZ) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera position
        transform.position = smoothedPosition;
    }
}
