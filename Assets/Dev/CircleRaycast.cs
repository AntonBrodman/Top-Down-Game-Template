using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRaycast : MonoBehaviour
{
    public float circleRadius = 0.5f; // Radius of the circle
    public float rayDistance = 10f;   // Distance the ray will travel
    public LayerMask hitLayers;       // Layers that the raycast can hit

    void Update()
    {
        // Define the origin of the raycast (can be the position of the GameObject)
        Vector2 origin = transform.position;

        // Define the direction of the raycast
        Vector2 direction = transform.right; // Right direction of the GameObject

        // Perform the circle raycast
        RaycastHit2D hit = Physics2D.CircleCast(origin, circleRadius, direction, rayDistance, hitLayers);

        // Check if the circle raycast hit something
        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            // You can add additional logic here for when the raycast hits something
        }
    }

    // Optionally, visualize the circle raycast in the Scene view
    void OnDrawGizmos()
    {
        // Only draw when the application is playing
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Vector2 origin = transform.position;
            Vector2 direction = transform.right;

            // Draw the circle at the origin
            Gizmos.DrawWireSphere(origin, circleRadius);

            // Draw the line representing the ray
            Gizmos.DrawLine(origin, origin + direction * rayDistance);

            // If a hit is detected, draw the hit point
            RaycastHit2D hit = Physics2D.CircleCast(origin, circleRadius, direction, rayDistance, hitLayers);
            if (hit.collider != null)
            {
                Gizmos.DrawWireSphere(hit.point, circleRadius);
            }
        }
    }
}
