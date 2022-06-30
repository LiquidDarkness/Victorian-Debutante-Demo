using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LiquidDarkness/" + nameof(LocalizableText))]
public class LocalizableText : ScriptableObject
{
    public TextAsset json;
    public Dictionary<string, StoryTexts> translations = new Dictionary<string, StoryTexts>();

    [ContextMenu("LoadTexts")]
    public void LoadTexts()
    {
        if (translations.Count > 0)
        {
            return;
        }
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