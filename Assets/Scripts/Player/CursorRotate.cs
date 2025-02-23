using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRotate : MonoBehaviour
{
    public int rotationOffset = 0; // Adjust if necessary

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        // Apply rotation without unintended offsets
        transform.rotation = Quaternion.Euler(0, 0, angle + rotationOffset);

        // Flip only on X-axis if necessary
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}

