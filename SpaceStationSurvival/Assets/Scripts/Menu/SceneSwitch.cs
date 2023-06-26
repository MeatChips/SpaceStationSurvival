using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public AudioSource StartGameSrc;
    public AudioSource GoToSettingsSrc;
    public AudioSource GoBackToMainMenuSrc;

    public Animator transition;
    public void StartGame(string sceneName)
    {
        print("Game Restarted");
        StartGameSrc.Play();
        StartCoroutine(DelaySceneLoad(sceneName));
        //if (!StartGameSrc.isPlaying)
        //{
        //    SceneManager.LoadScene(sceneName);
        //}
        //SceneManager.LoadScene("Main");
    }

    public void GoToSettings(string sceneName)
    {
        print("Go To Settings");
        GoToSettingsSrc.Play();
        StartCoroutine(DelaySceneLoad(sceneName));
        //if (!GoToSettingsSrc.isPlaying)
        //{
        //    SceneManager.LoadScene(sceneName);
        //}
        //SceneManager.LoadScene("Settings");
    }

    public void GoBackToMainMenu(string sceneName)
    {
        print("Go To Main");
        GoBackToMainMenuSrc.Play();
        StartCoroutine(DelaySceneLoad(sceneName));
        //if (!GoBackToMainMenuSrc.isPlaying)
        //{
        //    SceneManager.LoadScene(sceneName);
        //}
        //SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        print("Game Quitted");
        Application.Quit();
    }

    IEnumerator DelaySceneLoad(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }
}
