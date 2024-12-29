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
     
    //public void SwapWeapon(GameObject weapon)
    //{
    //    print(activeWeapon);

    //    activeWeapon = System.Array.Find(weapons, weapon => weapon.name == weapon.name);//
    //    print(activeWeapon);

    //}
    public void SwapWeapon(GameObject weapon)
    {
        print("Current active weapon: " + (activeWeapon != null ? activeWeapon.itemName : "None"));

        // Find the weapon in the array where the itemName matches the GameObject's name
        activeWeapon = System.Array.Find(weapons, w => w.itemName == weapon.name);

        if (activeWeapon != null)
        {
            print("New active weapon: " + activeWeapon.itemName);
        }
        else
        {
            print("No matching weapon found for: " + weapon.name);
        }
        //Instantiate(activeWeapon.weaponPrefab, transform.position, transform.rotation);
        GameObject NewWeapon = Instantiate(activeWeapon.weaponPrefab, transform.position, transform.rotation);
        NewWeapon.transform.SetParent(weaponPoint);


    }
    void EquipWeapon(string WeaponName)
    {

    }
}

