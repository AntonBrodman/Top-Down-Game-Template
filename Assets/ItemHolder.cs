using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public WeaponSO[] weapons;
    public WeaponSO activeWeapon;
    public ArmorSO [] armors;
    public ArmorSO activeArmor;
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
                    weaponInstance.transform.localPosition = new Vector3(1f, 0, 0); 
                    weaponInstance.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
                    playerDamage = weaponInstance.GetComponent<PlayerDamage>();
                    playerDamage.weapon = weapon;
                    playerDamage.Setter();

                }
            }
        }

        //print("Current active weapon: " + (activeWeapon != null ? activeWeapon.itemName : "None"));

            //// Find the weapon in the array where the itemName matches the GameObject's name
            //activeWeapon = System.Array.Find(weapons, w => w.itemName == weapon.name);

            //if (activeWeapon != null)
            //{
            //    print("New active weapon: " + activeWeapon.itemName);
            //}
            //else
            //{
            //    print("No matching weapon found for: " + weapon.name);
            //}
            


    }
}

