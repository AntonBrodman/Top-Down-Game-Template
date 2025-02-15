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


    void Start()
    {
        health = entityStats.Health;
        healthSlider.maxValue = entityStats.Health;

    }

    public virtual void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
       
    }
    public void TakeDamage(float demage)
    {
        health -= demage;
        if (health <= 0)
        {
            if(gameObject.tag == "Enemy")
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
