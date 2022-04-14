using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LiquidDarkness/" + nameof(LocalizableText))]
public class LocalizableText : ScriptableObject
{
    public TextAsset json;
    public Dictionary<string, StoryTexts> translations = new Dictionary<string, StoryTexts>();

    [RuntimeInitializeOnLoadMethod] //Ten atrybut automatycznie wykonuje statyczną metodę, do której jest podpisany.
    public static void LoadAllTexts()
    {
        LocalizableText[] texts = Resources.LoadAll<LocalizableText>(string.Empty);
        Debug.Log($"Found: {texts.Length}");
        foreach (var item in texts)
        {
            item.LoadTexts();
        }
    }

    [ContextMenu("LoadTexts")]
    private void LoadTexts()
    {
        ListWrapper wrapper = JsonUtility.FromJson<ListWrapper>(json.text);
        foreach (StoryTexts item in wrapper.Entries)
        {
            translations.Add(item.Language, item);
        }
    }

    [Serializable]
    class ListWrapper
    {
        public List<StoryTexts> Entries;
    }
}