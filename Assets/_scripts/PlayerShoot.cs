using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletPrefab;
    public AudioSource gunshotSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Pause.GameIsPaused)
        {
            gunshotSound.Play();
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
        }
    }
}
