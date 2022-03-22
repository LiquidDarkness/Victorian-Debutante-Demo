using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Object scene;
    public void NewGame()
    {
        PersistentSettings.PurgePlayerPrefs();
        ContinueGame();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(scene.name);
    }
}
