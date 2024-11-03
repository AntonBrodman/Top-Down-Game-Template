using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{   
    void Passive(Transform Player) // running from palayer
    {
        Vector2 directionToPlayer = Player.position - transform.position;
        Vector2 moveDirection = -directionToPlayer.normalized;
        //transform.Translate(moveDirection * EnemySpeed * Time.deltaTime);
    }
}
