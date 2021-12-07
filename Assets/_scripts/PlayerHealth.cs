using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;


    public GameObject deathCanvas;

    private void Awake()
    {
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            deathCanvas.SetActive(true);
            Time.timeScale = 0f;
            //Destroy(this.gameObject);
        }
    }
}
