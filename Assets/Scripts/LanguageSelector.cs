using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LanguageSelector : MonoBehaviour
{
    // - opcja wyboru jêzyka,
    // - dostêp do dostêpnych jêzyków,
    // - obecnie wybrany jêzyk <string>,

    public LocalizableText localizableText;
    public static string CurrentLanguage
    {
        get;
        private set;
    } = "EN";

    [ContextMenu("Test SetLanguage")]
    public void TestSet()
    {
        SetLanguage("PL");
        Debug.Log($"Language set: {CurrentLanguage}");
    }
    [ContextMenu("Test AvailableLanguages")]
    public void ListAvailableLanguages()
    {
        Debug.Log($"First element from the list: {localizableText.translations.Keys.First()}");
    }

    public void SetLanguage(string chosenLanguage)
    {
        CurrentLanguage = chosenLanguage;
    }

}
public class LanguageButton
{
    public void Clicked()
    {
        var selector = new LanguageSelector();
        selector.SetLanguage("PL");
    }
}

