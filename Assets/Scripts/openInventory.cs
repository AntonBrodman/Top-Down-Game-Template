using System;
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
    public ItemHolder itemHolder;
    public LoadItems itemLoader;
    public int ItemId;

    public enum buttonType
    {
        mainInventory,
        itemSelection
    }
    public buttonType button;

    private void Start()
    {
        print("gat");
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

                Transform childTransform = weaponPoint.transform.GetChild(0);
                itemHolder = weaponPoint.GetComponentInParent<ItemHolder>();

                print("clicked: " + gameObject.name);
                PlayerDamage PlayerDamage = GetComponent<PlayerDamage>();
                ItemId = Int32.Parse(gameObject.name);
                itemHolder.SwapWeapon(ItemId);
                break;
        }
    }
    void OpenItems()
    {
        ItemsPanel.SetActive(true);
        Inventory.SetActive(false);
        itemLoader.Load();
    }
    public void SetId(int id)
    {
        ItemId = id;
    }
}
