using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]

public class WeaponSO : ScriptableObject
{
    public string itemName;
    public int id;
    public float damage;
    public float staminaCost;
    public GameObject WeaponPrefab;
    public Sprite WeaponSprite;
    public Sprite WeaponIcon;
}





