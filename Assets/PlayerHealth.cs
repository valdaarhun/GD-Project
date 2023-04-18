using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    [SerializeField]
    TextMeshProUGUI healthText;

    void Start()
    {
        health = Health.currentHealth;
        updateHealthText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet"){
            Health.currentHealth -= 5;
            health = Health.currentHealth;
            updateHealthText();
            if (Health.currentHealth <= 0){
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void updateHealthText()
    {
        healthText.text = "health: " + Health.currentHealth.ToString();
    }
}
