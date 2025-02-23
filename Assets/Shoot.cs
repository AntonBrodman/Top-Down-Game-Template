using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector
    public Transform firePoint; // Assign a child GameObject that represents the fire point
    public float projectileSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left mouse button or mapped fire button
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * projectileSpeed; // Fire in the direction the pistol is facing
        }
    }
}
