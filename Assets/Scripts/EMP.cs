using System.Collections;
using UnityEngine;

public class EMP : MonoBehaviour
{
    private float radius;
    public CircleCollider2D circleCollider;

    void Start()
    {
        print("EMP start");
        StartCoroutine(EMPAttack());
    }

    private IEnumerator EMPAttack()
    {
        // Delay for 1 second before starting to grow the radius
        yield return new WaitForSeconds(1f);

        float growthDuration = 1f;     // Total time for growth
        float growthEndTime = Time.time + growthDuration;

        while (Time.time < growthEndTime)
        {
            radius += 1f * Time.deltaTime * 10; // Adjust growth rate to control speed
            print(radius);

            // Update the collider radius (if applicable)
            if (circleCollider != null)
            {
                circleCollider.radius = radius;
            }

            yield return null; // Wait until the next frame
        }

        print("Radius growth complete.");
    }
}
