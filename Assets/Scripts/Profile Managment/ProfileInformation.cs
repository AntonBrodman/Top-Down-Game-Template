using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProfileInformation 
{
    public string profileName;
    public int id;
    public int health;
    public float currentHealth;
    public int healCharges;
    public int stamina;
    public List<WeaponSO> inventory = new List<WeaponSO>();
    public Vector3 lastLocation;

}
