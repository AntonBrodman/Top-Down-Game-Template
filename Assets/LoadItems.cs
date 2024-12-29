using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadItems : MonoBehaviour
{
    public ItemHolder items;
    public GameObject panelPrefab;
    public GameObject itemRenderer;
    public GameObject mainInventory;
    public GameObject weaponHolder;
    private void Start()
    {
        Load();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            itemRenderer.SetActive(false);
            mainInventory.SetActive(true);

        }
    }
    void Load()
    {
        foreach (var item in items.weapons)
        {
            AddPanel(item); 
            // add panel to holder of this script
        }


    }
    void AddPanel(WeaponSO item)
    {
        GameObject newPanel = Instantiate(panelPrefab, transform);
        newPanel.name = item.name;

        TextMeshProUGUI panelText = newPanel.GetComponentInChildren<TextMeshProUGUI>();
        Image image = newPanel.GetComponentInChildren<Image>();

        if (panelText != null)
        {
            panelText.text = item.name; 
        }

        if (image != null)
        {
            image.sprite = item.Sprite; 
        }

    }

}
