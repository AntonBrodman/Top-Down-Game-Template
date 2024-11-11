using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    private float radius;
    private bool isGrowing = false;
    public CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EMPAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator EMPAttack()
    {
        yield return new WaitForSeconds(1f);
        isGrowing = true;
        while (isGrowing)
        {
            radius += 0.1f;
            print(radius);
        }
        yield return new WaitForSeconds(2f);

    }
}
