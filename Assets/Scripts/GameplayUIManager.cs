using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    public Button mainMenuutton;
    public Button continueButton;
    public Button mainMenuShortcut;
    public Object mainMenu;
    public GameObject notifWindow;

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
        SceneManager.LoadScene(mainMenu.name);
    }
}
