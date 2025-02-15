using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveScript : MonoBehaviour
{   
    public void Passive(Transform target,float speed) 
    {
        //print("keeping distace");
        
        Vector2 directionToPlayer = target.position - transform.position;
        Vector2 moveDirection = -directionToPlayer.normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
