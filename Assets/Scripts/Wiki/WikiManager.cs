using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WikiManager : MonoBehaviour
{
    public GameObject entryButtonPrefab;
    public Transform entryButtonContainer;

    private List<WikiEntryMetadata> wikiEntries = new List<WikiEntryMetadata>();

    private void Start()
    {
        // Load the wiki entries from JSON file
        string jsonFilePath = "Assets/WikiEntries.json";
        string jsonData = File.ReadAllText(jsonFilePath);
        WikiEntryList entryList = JsonUtility.FromJson<WikiEntryList>(jsonData);
        wikiEntries = entryList.entries;

        // Populate the entry buttons
        foreach (WikiEntryMetadata entry in wikiEntries)
        {
            // Create a new entry button from the prefab
            GameObject entryButton = Instantiate(entryButtonPrefab, entryButtonContainer);

            // Set the button label to the entry name in the correct language
            Text buttonLabel = entryButton.GetComponentInChildren<Text>();
            buttonLabel.text = entry.GetNameInLanguage("English"); // Replace "English" with your desired language

            // Add a click event to the button to display the entry content
            entryButton.GetComponent<Button>().onClick.AddListener(() => ShowEntryContent(entry));
        }
    }

    private void ShowEntryContent(WikiEntryMetadata entry)
    {
        // TODO: Display the content of the selected entry
    }
}

[System.Serializable]
public class WikiEntryList
{
    public List<WikiEntryMetadata> entries;
}
