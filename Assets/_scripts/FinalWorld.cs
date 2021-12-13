using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalWorld : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene(3);

    }
}
