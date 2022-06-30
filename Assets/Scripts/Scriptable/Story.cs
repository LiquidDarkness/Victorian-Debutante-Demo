using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LiquidDarkness/" + nameof(Story))]
public class Story : ScriptableObject
{
    [SerializeReference] LocalizableText storyTexts;
    [SerializeField] Story nextStory;
    public AudioClip introStoryMusic;
    public AudioClip storyMusicLoop;
    public PivotData[] pivotsData;
    public int DecisionCount { get => 4; }
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

    public string GetResult(int index)
    {
        switch (index)
        {
            case 0: return ResultA;
            case 1: return ResultB;
            case 2: return ResultC;
            case 3: return ResultD;

            default: return string.Empty;
        }
    }

    public string GetDecision(int index)
    {
        switch (index)
        {
            case 0: return DecisionA;
            case 1: return DecisionB;
            case 2: return DecisionC;
            case 3: return DecisionD;

            default: return string.Empty;
        }
    }

    [ContextMenu("Test")]
    public void Test()
    {
        Debug.Log(StoryText);
    }

    public void OnEnable()
    {
        storyTexts.LoadTexts();
    }

    [Serializable]
    public struct PivotData
    {
        public List<PointsData> pointsData;
    }

    [Serializable]
    public struct PointsData
    {
        public int points;
        public Story story;
    }
}
