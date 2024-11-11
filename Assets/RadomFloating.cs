using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomFloating : MonoBehaviour
{
    public float speed = 2f;       // Movement speed
    public float radius = 5f;      // Radius limit from original position

    private Vector2 startPosition; // Store the starting position
    private Vector2 targetPosition; // Random target position within the radius

    void Start()
    {
        startPosition = transform.position;
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if reached or close to target position, then set a new target
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Generate a random point within the circle defined by radius
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(0, radius);

        // Calculate new target position within the circle
        targetPosition = startPosition + randomDirection * randomDistance;
    }
}
