using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class openInventory : MonoBehaviour
{
    public GameObject ItemsPanel;
    public GameObject Inventory;
    public GameObject weaponPoint;
    public GameObject currentWeapon;
    public ItemHolder itemHolder;
    public enum buttonType
    {
        mainInventory,
        itemSelection
    }
    public buttonType button;

    private void Start()
    {
        
    }
    public void OnButtonClick()
    {
        switch (button)
        {
            case buttonType.mainInventory:
                OpenItems();

                break;


            case buttonType.itemSelection:                
                GameObject weaponPoint = GameObject.Find("AnimationPoint");
                
                Transform childTransform = weaponPoint.transform.GetChild(0); // Gets the first child
                itemHolder = weaponPoint.GetComponentInParent<ItemHolder>();

                GameObject currentWeapon = childTransform.gameObject;
                Destroy(currentWeapon);

                //if (childTransform != null)
                //{
                //    break;
                //}
                //itemHolder.activeWeapon = itemHolder.weapons.Find(gameObject);
                //print(itemHolder.activeWeapon + "  gay " + itemHolder.weapons);
                print("clicked: " + gameObject.name);

                itemHolder.SwapWeapon(gameObject);
                //print(itemHolder.activeWeapon + "  gay " + itemHolder.weapons);
                
                childTransform.parent = null;
                



                break;

        }
            

    }
    void OpenItems()
    {
        ItemsPanel.SetActive(true);
        Inventory.SetActive(false);
    }
    
}
