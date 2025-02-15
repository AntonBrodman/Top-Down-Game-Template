using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public WeaponSO itemContext;
    public Transform player;
    public GameObject ui;
    public float pickUpRadius;
    private Collider2D pickUpCollider;
    public Movement movement;
    public GameObject item;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movement = player.GetComponent<Movement>();
        ui.SetActive(false);
        pickUpCollider = gameObject.GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item"){
            itemContext = collision.gameObject.GetComponent<ItemInfo>().item;
            ui.SetActive(true);
            item = collision.gameObject;
            movement.canInteract = true;

      
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            ui.SetActive(false);
            movement.canInteract = false;


        }
    }
    public void Destoy()
    {
        Destroy(item);
    }


}

