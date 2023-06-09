using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void RestartGame()
    {
        print("Game Restarted");
        SceneManager.LoadScene("Main");
    }

    public void GoBackToMainMenu()
    {
        print("Go To Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        print("Game Quitted");
        Application.Quit();
    }
}
