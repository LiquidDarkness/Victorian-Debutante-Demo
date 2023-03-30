using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WikiContentLoader : MonoBehaviour
{
    private Dictionary<string, WikiEntryMetadata> encyclopaedia = new Dictionary<string, WikiEntryMetadata>();
    private string jsonFilePath = "Assets/wiki_entries.json"; // change this to the file path of your JSON file

    void Awake()
    {
        LoadEncyclopaedia();
    }

    void LoadEncyclopaedia()
    {
        string jsonString = File.ReadAllText(jsonFilePath);
        EncyclopaediaData data = JsonUtility.FromJson<EncyclopaediaData>(jsonString);

        foreach (WikiEntryMetadata entry in data.entries)
        {
            if (!string.IsNullOrEmpty(entry.id))
            {
                encyclopaedia.Add(entry.id, entry);
            }
            else
            {
                Debug.LogWarning("Skipping entry with null or empty title.");
            }
        }
    }


    public void UnloadEncyclopaedia()
    {
        encyclopaedia.Clear();
    }

    public WikiEntryMetadata GetEncyclopaediaEntry(string id)
    {
        if (encyclopaedia.ContainsKey(id))
        {
            return encyclopaedia[id];
        }
        else
        {
            Debug.LogError("Encyclopaedia entry not found: " + id);
            return null;
        }
    }
}

[System.Serializable]
public class EncyclopaediaData
{
    public List<WikiEntryMetadata> entries;
}
