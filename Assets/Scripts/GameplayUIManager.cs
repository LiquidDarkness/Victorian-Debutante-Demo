using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    public Button mainMenuButton;
    public Button continueButton;
    public Button mainMenuShortcut;
    public Button finishedGameButton;
    public SceneReference scene;
    public GameObject notifWindow;
    public GameObject optionsWindow;

    public void OpenNotifWindow()
    {
        notifWindow.SetActive(true);
    }
   
    public void CloseNotifWindow()
    {
        notifWindow.SetActive(false);
    }   
    
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(scene.SceneName);
    }

    public void OpenOptionsWindow()
    {
        optionsWindow.SetActive(true);
    }

    public void CloseOptionsWindow()
    {
        optionsWindow.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
