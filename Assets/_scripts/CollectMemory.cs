using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMemory : MonoBehaviour
{
    public AudioSource collectSound;


    public void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore += 1;
        Destroy(gameObject);

    }
}
