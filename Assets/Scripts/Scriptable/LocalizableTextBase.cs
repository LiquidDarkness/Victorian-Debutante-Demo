using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class LocalizableTextBase<TEntry> : ScriptableObject
where TEntry : LocalizableItemBase
{
    public TextAsset json;
    public Dictionary<string, TEntry> translations = new Dictionary<string, TEntry>();

    [ContextMenu("LoadTexts")]
    public void LoadTexts()
    {
        if (translations.Count > 0)
        {
            return;
        }
        ListWrapper wrapper = JsonUtility.FromJson<ListWrapper>(json.text);
        foreach (TEntry item in wrapper.entries)
        {
            translations.Add(item.language, item);
        }
    }

    [Serializable]
    class ListWrapper
    {
        public List<TEntry> entries;
    }
}
