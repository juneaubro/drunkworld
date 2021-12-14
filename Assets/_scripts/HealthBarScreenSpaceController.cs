using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScreenSpaceController : MonoBehaviour
{
    [Header("Health Properties")]
    [Range(0, 100)]
    public int currentHealth = 100;

    [Range(1, 100)]
    public int maximumHealth = 100;

    private Slider healthBarSlider;

    public GameObject playerCamera;

    public GameObject endMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider = GetComponent<Slider>();
        currentHealth = maximumHealth;
        playerCamera = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        healthBarSlider.value -= damage;
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            endMenuUI.SetActive(true);
            healthBarSlider.value = 0;
            currentHealth = 0;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            playerCamera.GetComponent<CameraController>().enabled = false;
        }
    }

    public void SetHealth(int healthValue)
    {
        healthBarSlider.value = healthValue;
        currentHealth = healthValue;
    }

    public void Reset()
    {
        healthBarSlider.value = maximumHealth;
        currentHealth = maximumHealth;
    }

    public void GainHealth(int healAmount)
    {
        healthBarSlider.value += healAmount;
        currentHealth += healAmount;
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }
}
