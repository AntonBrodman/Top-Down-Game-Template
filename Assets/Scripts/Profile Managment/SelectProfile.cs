using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SelectProfile : MonoBehaviour
{
    public GameObject Manager;
    public MainMenuButtonFunctions ManagerScript;
    private void Start()
    {
        Manager = GameObject.Find("Main Menu Manager");
        ManagerScript = Manager.GetComponent<MainMenuButtonFunctions>();
    }
    public void SelectThis()
    {
        TextMeshProUGUI panelText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        print("selected profile id: "+this.name);
        ManagerScript.setProfileId(Int32.Parse(this.name));
    }
}
