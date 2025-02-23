using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public List<WeaponSO> weapons = new List<WeaponSO>();
    public WeaponSO activeWeapon;
  
    public Transform weaponPoint;
    public PlayerDamage playerDamage;

    public void SwapWeapon(int id) // Swaps weapon based on parametr id of a weapon
    {
        foreach (var weapon in weapons)
        {
            if(weapon.id == id)
            {
                if (activeWeapon.id == id)
                {
                    break;
                }
                else
                {
                    foreach (Transform child in weaponPoint.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    activeWeapon = weapon;

                    GameObject weaponInstance = Instantiate(activeWeapon.WeaponPrefab, transform.position, transform.rotation);
                    weaponInstance.transform.SetParent(weaponPoint);
                    weaponInstance.transform.localPosition = new Vector3(0, 0, 0); 
                    weaponInstance.transform.localRotation = Quaternion.Euler(0f, 0f, 0);
                    playerDamage = weaponInstance.GetComponent<PlayerDamage>();
                    //playerDamage.weapon = weapon;

                }
            }
        }

    }
    public void AddItem(WeaponSO item) // Adds scriptable object of a weapon to weapon list
    {
        weapons.Add(item);
    }
}

