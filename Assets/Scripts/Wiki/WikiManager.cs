using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WikiManager : MonoBehaviour
{
    private const string filePath = "WikiEntries";
    [SerializeReference] LocalizableWikiEntry wikiTexts;
    public GameObject entryButtonPrefab;
    public Text entryBody;
    public Transform entryButtonContainer;
    public bool loadJSONsOnly;

    public string Title
    {
        get => wikiTexts.translations[LanguageSelector.CurrentLanguage].title;
    }
    
    public string EntryBody
    {
        get => wikiTexts.translations[LanguageSelector.CurrentLanguage].entryBody;
    }

    private List<Button> wikiButtons = new List<Button>();

    private void Start()
    {
        // Load the wiki entries from JSON file

        LocalizableWikiEntry[] wikiEntries = LoadEntries();

        // Populate the entry buttons
        foreach (LocalizableWikiEntry entry in wikiEntries)
        {
            // Create a new entry button from the prefab
            GameObject entryButton = Instantiate(entryButtonPrefab, entryButtonContainer);
            entryBody.gameObject.SetActive(false); // aktywuj game object
            int index = entryButtonContainer.GetSiblingIndex();
            Transform child = entryButtonContainer.GetChild(index + 1);

            // Set the button label to the entry name in the correct language
            Text buttonLabel = entryButton.GetComponentInChildren<Text>();
            buttonLabel.text = entry.translations[LanguageSelector.CurrentLanguage].title;            
            //Text entryText = entryBodyText.GetComponent<Text>();

            // Add a click event to the button to display the entry content
            //entryButton.GetComponent<Button>().onClick.AddListener(() => ShowEntryContent(entry.translations[LanguageSelector.CurrentLanguage]));
            Button buttonComponent = entryButton.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => DisplayEntryBody(entryButton.transform, entry));
        }

        entryBody.transform.SetAsLastSibling();
    }

    private LocalizableWikiEntry[] LoadEntries()
    {
        if (loadJSONsOnly)
        {
            return LoadJSONsFromResources();
        }
        else
        {
            return LoadAllFromResources();
        }
    }

    private static LocalizableWikiEntry[] LoadAllFromResources()
    {
        // Load all ScriptableObjects from the "LocalizableWikiEntrys" folder
        LocalizableWikiEntry[] wikiEntries = Resources.LoadAll<LocalizableWikiEntry>(filePath);

        // Perform some actions on them
        foreach (LocalizableWikiEntry wikiTexts in wikiEntries)
        {
            wikiTexts.LoadTexts();
        }

        return wikiEntries;
    }

    private static LocalizableWikiEntry[] LoadJSONsFromResources()
    {
        // Load all ScriptableObjects from the "LocalizableWikiEntrys" folder
        TextAsset[] rawEntries = Resources.LoadAll<TextAsset>(filePath);
        LocalizableWikiEntry[] wikiEntries = new LocalizableWikiEntry[rawEntries.Length];

        // Perform some actions on them
        for (int i = 0; i < rawEntries.Length; i++)
        {
            var wikiEntry = wikiEntries[i] = ScriptableObject.CreateInstance<LocalizableWikiEntry>();
            wikiEntry.json = rawEntries[i];
            wikiEntry.LoadTexts();
        }

        return wikiEntries;
    }

    public void ShowEntryContent()
    {
        // TODO: Display the content of the selected entry

        entryBody.gameObject.SetActive(!entryBody.gameObject.activeSelf); // aktywuj game object
    }

    void DisplayEntryBody(Transform entryButton, LocalizableWikiEntry entry)
    {
        entryBody.gameObject.SetActive(!entryBody.gameObject.activeSelf); // prze³¹cz tryb aktywnoœci
        int index = entryButton.GetSiblingIndex() + 1;
        entryBody.transform.SetSiblingIndex(index);
        entryBody.text = entry.translations[LanguageSelector.CurrentLanguage].entryBody;
    }
}
