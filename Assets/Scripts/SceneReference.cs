using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneReference : ScriptableObject
{
    [SerializeField] Object scene;
    [SerializeField, HideInInspector] string sceneName;
    public string SceneName => sceneName;

    public void Reset()
    {
        SceneNamer();
        name = scene?.name;
    }

    private void SceneNamer()
    {
        if(scene == null)
        {
            return;
        }
        
        sceneName = scene.name;
    }
}
