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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            itemRenderer.SetActive(false);
            mainInventory.SetActive(true);

        }
    }
    public void Load()
    {
        ClearPanels();
        foreach (var item in items.weapons)
        {
            AddPanel(item);
        }
    }

    void ClearPanels()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void AddPanel(WeaponSO item)
    {
        GameObject newPanel = Instantiate(panelPrefab, transform);
        newPanel.name = item.id.ToString();

        TextMeshProUGUI panelText = newPanel.GetComponentInChildren<TextMeshProUGUI>();
        Image image = newPanel.GetComponentInChildren<Image>();

        if (panelText != null)
        {
            panelText.text = item.name + item.id;
        }

        if (image != null)
        {
            image.sprite = item.WeaponIcon;
        }
    }

}
