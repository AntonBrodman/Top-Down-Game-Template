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

    public void SwapWeapon(int id)
    {
        foreach (var weapon in weapons)
        {
            if(weapon.id == id)
            {
                print(weapon.name);
                if (activeWeapon.id == id)
                {
                    print("same weapon");
                    break;
                }
                else
                {
                    print(activeWeapon);
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
                    playerDamage.weapon = weapon;
                    playerDamage.Setter();

                }
            }
        }

    }
    public void AddItem(WeaponSO item)
    {

        
        weapons.Add(item);
        print(weapons);
    }
}

