using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{   
    void Passive(Transform target,float speed) 
    {
        Vector2 directionToPlayer = target.position - transform.position;
        Vector2 moveDirection = -directionToPlayer.normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
