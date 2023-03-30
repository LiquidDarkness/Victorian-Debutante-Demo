using System.Collections.Generic;

[System.Serializable]
public class WikiEntryMetadata
{
    public string id;
    public Dictionary<string, string> names; // Dictionary to store entry names in different languages
    public string content;

    public string GetNameInLanguage(string language)
    {
        if (names != null && names.ContainsKey(language))
        {
            return names[language];
        }
        else
        {
            return "N/A";
        }
    }

}
