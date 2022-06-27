using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Object scene;
    public GameObject creditsWindow;


    public void NewGame()
    {
        PersistentSettings.PurgePlayerPrefs();
        SceneManager.LoadScene(scene.name);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(scene.name);
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
