using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDisplayer : MonoBehaviour
{
    public Image imageDisplay;
    public Text textDisplay;
    public Text decisionDisplay;
    public Animator animator;
    public TextInstantiator textInstantiator;

    public bool ShouldBePicked { set => animator.SetBool(nameof(ShouldBePicked), value); }

    internal void DisplayStory(Story story)
    {
        imageDisplay.sprite = story.StoryImage;
        textDisplay.text = story.StoryText;
        textInstantiator.FillTexts(story.GetDecision, story.DecisionCount);
    }
    internal void DisplayResponseText(string decisionText)
    {
        decisionDisplay.text = decisionText;
        ShouldBePicked = true;
    }

    [ContextMenu("Test")]
    void Test()
    {
        DisplayStory(Resources.LoadAll<Story>("Stories")[0]);
    }
}
