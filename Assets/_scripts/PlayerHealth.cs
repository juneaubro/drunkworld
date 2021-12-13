using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public GameObject healthBarCanvas;

    private void Start()
    {
        healthBarCanvas = GameObject.Find("HealthBar-ScreenSpace");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarCanvas.GetComponent<HealthBarScreenSpaceController>().TakeDamage(damage);
        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOVer");
        }
    }
}
