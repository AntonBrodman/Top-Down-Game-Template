using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Stats/Player Stats")]

public class PlayerStats : EntityStats
{
    public float Stamina;
    //public float Strenght;
    //public float Dexterity;
    //public float PhysicalRes;



    // constant stats
    public float moveSpeed = 3f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public float rollCost = 30f;
    //heal stats
    public float healDuration = 1f;
    public float healValue; 
    public float healMovementSpeed;

}
