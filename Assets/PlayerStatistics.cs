using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Statistics", menuName = "Stats/Player Statistics")]

public class PlayerStatistics : ScriptableObject
{
    public float Health;
    public float Stamina;
    public float Strenght;
    public float Dexterity;
    public float PhysicalRes;



    // constant stats
    public float moveSpeed = 0f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float healDuration = 1f;
    public float dashCooldown = 1f;
    public float rollCost = 30f;

}
