using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Stats/Player Stats")]

public class PlayerStats : EntityStats
{
    public float Stamina;
    public float walkSpeed = 1f;
    public float sprintSpeed = 3f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public float rollCost = 30f;
    public float healDuration = 1f;
    public float healValue; 
    public float healMovementSpeed;

}
