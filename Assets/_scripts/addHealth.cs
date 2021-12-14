using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addHealth : MonoBehaviour
{
    public int healAmount = 20;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthBarScreenSpaceController playerhealth = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarScreenSpaceController>();
            playerhealth.GainHealth(healAmount);
            Destroy(this.gameObject);
        }
        

    }
}
