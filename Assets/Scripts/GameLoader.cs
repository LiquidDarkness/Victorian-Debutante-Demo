using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public SceneReference scene;
    public GameObject creditsWindow;


    public void NewGame()
    {
        PersistentSettings.PurgePlayerPrefs();
        SceneManager.LoadScene(scene.SceneName);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(scene.SceneName);
    }

    public void OpenCreditsWindow()
    {
        creditsWindow.SetActive(true);
    }

    public void CloseCreditsWindow()
    {
        creditsWindow.SetActive(false);
    }
}
