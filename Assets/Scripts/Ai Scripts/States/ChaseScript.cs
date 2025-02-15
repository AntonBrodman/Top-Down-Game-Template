using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    public void Chase(Transform target, Rigidbody2D chaserRg, float chaseSpeed)
    {
        //print("chasing");
        Vector2 direction = (target.position - transform.position).normalized;
        chaserRg.velocity = direction * chaseSpeed;
    }
}
