using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public EnemyStats stats;
    private Transform Player;
    public float patrolSpeed;
    public ChaseScript chaseScript;
    public PatrolScript patrolScript;
    public float detectRadius;

    private Rigidbody2D rigidbody2D;
   // public enum states { Patrol, Chase, Passive, Search, Combat };


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        patrolSpeed = stats.patrolSpeed;
    }

    void Update()
    {
        if (Player == null) return;
        float distance = Vector2.Distance(transform.position, Player.position);
        if (distance < detectRadius)
        {
            chaseScript.Chase(Player, rigidbody2D, patrolSpeed);

        }
        else
        {
            patrolScript.Patrol(patrolSpeed);
        }
    }

}
