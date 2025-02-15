using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public EnemyStats stats;
    public Transform Player;
    public float patrolSpeed;
    //states
    public ChaseScript chaseState;
    public PatrolScript patrolState;
    public CombatScript combatState;
    public PassiveScript passiveState;
    public float detectRadius;
    public float distanceKept;
    private Rigidbody2D rigidbody2D;
    public bool playerDetected = false;
    public float chaseSpeed;
   // public enum states { Patrol, Chase, Passive, Combat };


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
        if (distance < detectRadius && !playerDetected)
        {
            print("detected");
            playerDetected = true;
        }
        if (distance > detectRadius*2 && playerDetected)
        {
            
            playerDetected = false;
        }
        switch (playerDetected)
        {
            case true:
                if (distance < 2f)
                {
                    combatState.Combat();
                }
                else
                {
                    chaseState.Chase(Player, rigidbody2D, chaseSpeed);

                }
                break;
            case false:
                patrolState.Patrol(patrolSpeed);
                
                break;
        }

    }

}
