using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponRotate : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        RotateTowardsTarget(270f);
    }
    private void RotateTowardsTarget(float offset)
    {
        Vector2 direction = Player.position - transform.position; // 
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
