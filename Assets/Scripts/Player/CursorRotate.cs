using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRotate : MonoBehaviour
{
    void Update()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0; // Ensure z position is zero for 2D space
        Vector3 cursorDirection = cursorPosition - transform.position;

        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the object to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle between the object's forward direction and the direction to the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (cursorDirection.x < 0)
        {
            //right from player

            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);

            // transform y to negative
        }
        else
        {
            //left from player
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }

    }
}

