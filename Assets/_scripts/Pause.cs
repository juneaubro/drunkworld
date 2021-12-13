using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject playerCamera;
    public GameObject pauseMenuUI;

    private void Start() {
        playerCamera = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera.GetComponent<CameraController>().enabled = true;
    }
     void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        playerCamera.GetComponent<CameraController>().enabled = false;
    }
}
