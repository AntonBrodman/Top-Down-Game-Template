using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public EntityStats entityStats;
    public Slider healthSlider;
    public float health;
    //public GameObject gameObject;
    //public float healCharges;

    void Start()
    {
        health = entityStats.Health;
        healthSlider.maxValue = entityStats.Health;
        //gameObject = 
        //print(gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
       
    }
    public void TakeDamage(float demage)
    {
        health -= demage    ;
        if (health <= 0)
        {
            print("Died");
            if(gameObject.tag == "Player")
            {
                SceneManager.LoadScene("Visuals");


            }
            else if(gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }

        }
    }
    public void Heal(float heal)
    {

        if (health >= entityStats.Health)
        {
            return;
        }
        else
        {
            health += heal;
            if (health > entityStats.Health)
            {
                health = entityStats.Health;
            }

        }
    }
}
