using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Object scene;
    public Story firstStory;

    public void NewGame()
    {
        PersistentSettings.PurgePlayerPrefs();
        StoryManager.firstStory = firstStory;
        SceneManager.LoadScene(scene.name);
    }

    public void ContinueGame()
    {
        StoryManager.firstStory = StoryManager.SavedStory;
        SceneManager.LoadScene(scene.name);
    }
}
