using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LOAD_SCENE(string SceneName)
    {
        if (SceneName == "Menu" || SceneName == "Options" || SceneName == "Instructions")
            SceneManager.LoadScene(SceneName);
        else {
            Time.timeScale = 1f;
            Pause.GameIsPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene(SceneName);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
