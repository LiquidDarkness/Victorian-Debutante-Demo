using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LiquidDarkness/" + nameof(Story))]
public class Story : ScriptableObject
{
    [SerializeField] LocalizableText storyTexts;
    [SerializeField] Story nextStory;
    public virtual Story NextStory { get => nextStory; }
    public string StoryText
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].StoryText;
    }
    public string DecisionA
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].DecisionA;
    }

    public string ResultA
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].ResultA;
    }

    public string DecisionB
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].DecisionB;
    }

    public string ResultB
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].ResultB;
    }
    public string DecisionC
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].DecisionC;
    }

    public string ResultC
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].ResultC;
    }

    public string DecisionD
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].DecisionD;
    }

    public string ResultD
    {
        get => storyTexts.translations[LanguageSelector.CurrentLanguage].ResultD;
    }

    public Sprite StoryImage 
    { 
        get => Resources.Load<Sprite>($"Stories/StoryImages/{this.name}"); 
    }

    [ContextMenu("Test")]
    public void Test()
    {
        Debug.Log(StoryText);
    }
}
