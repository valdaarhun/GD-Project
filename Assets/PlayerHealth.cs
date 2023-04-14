using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    void Start()
    {
        health = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet"){
            health -= 5;
            if (health <= 0){
                Destroy(gameObject);
            }
        }
    }
}
