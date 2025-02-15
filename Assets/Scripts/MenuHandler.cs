using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject backpack;

    private bool isMenuActive = false;
    private bool isBackpackActive = false;
    public bool uiIsOpen = false;

    void Start()
    {

        menuPanel.SetActive(false);
        backpack.SetActive(false);

    }

    void Update()
    {
        // Check if the ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        if (Input.GetKeyDown(KeyCode.Tab) && isMenuActive != true)
        {
            ToggleBackpack();
        }
        if(isMenuActive || isBackpackActive)
        {
            uiIsOpen = true;
        }
        else
        {
            uiIsOpen = false;
        }
        //Debug.Log(uiIsOpen);
    }

    void ToggleMenu()
    {

        isMenuActive = !isMenuActive;
        menuPanel.SetActive(isMenuActive);

    }
    void ToggleBackpack()
    {
        isBackpackActive = !isBackpackActive;
        backpack.SetActive(isBackpackActive);
    }

}

