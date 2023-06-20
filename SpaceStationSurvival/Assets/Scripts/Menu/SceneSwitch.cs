using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void StartGame()
    {
        print("Game Restarted");
        SceneManager.LoadScene("Main");
    }

    public void GoToSettings()
    {
        print("Go To Settings");
        SceneManager.LoadScene("Settings");
    }

    public void GoBackToMainMenu()
    {
        print("Go To Main");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        print("Game Quitted");
        Application.Quit();
    }
}
