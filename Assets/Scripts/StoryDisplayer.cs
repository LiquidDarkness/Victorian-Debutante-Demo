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

    public bool ShouldBePicked { set => animator.SetBool(nameof(ShouldBePicked), value); }

    public void DisplayStoryText(StoryBoxes story)
    {
        imageDisplay.sprite = story.storyImage;
        textDisplay.text = story.storyText;
        ShouldBePicked = false;
    }

    internal void DisplayStoryText(Story story)
    {
        imageDisplay.sprite = story.StoryImage;
        textDisplay.text = story.StoryText;
    }
    internal void DisplayResponseText(string decisionText)
    {
        decisionDisplay.text = decisionText;
        ShouldBePicked = true;
    }

    [ContextMenu("Test")]
    void Test()
    {
        DisplayStoryText(Resources.LoadAll<Story>("Stories")[0]);
    }
}
