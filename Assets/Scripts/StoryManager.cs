using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    private const string storiesLocationInResources = "Stories/Stories/";
    private const string failsafeStory = "01";
    private const string savedStoryKey = "savedStoryKey";
    [NonSerialized] public Story currentStory;
    [SerializeField] Story firstStory;
    [SerializeField] StoryDisplayer storyDisplayer;

    public static Story SavedStory {
        get
        {
            string storyName = PlayerPrefs.GetString(savedStoryKey, failsafeStory);
            return Resources.Load<Story>($"{storiesLocationInResources}{storyName}");
        }

        set
        {
            string storyName = value.name;
            PlayerPrefs.SetString(savedStoryKey, storyName);
        }
    }

    void Awake()
    {
        currentStory = SavedStory ?? firstStory;
    }

    private void Start()
    {
        Debug.Log(currentStory);
        storyDisplayer.DisplayStory(currentStory);
    }

    [UsedImplicitly]
    public void ProceedToNextStory()
    {
        if (currentStory.NextStory != null)
        {
            currentStory = LoadNextStory();
            SavedStory = currentStory;
            storyDisplayer.DisplayStory(currentStory);
            return;
        }
    }

    private Story LoadNextStory()
    {
        return currentStory.NextStory;
    }

    /*
    [ContextMenu("Test")]
    void Test()
    {
        storyDisplayer.DisplayStory(firstStory);
        Debug.Log(firstStory.StoryText);
    }

    [ContextMenu("TestA")]
    void TestSelectDecisionA()
    {
        storyDisplayer.DisplayResponseText(firstStory.ResultA);
        Debug.Log(firstStory.DecisionA);
    }
    */
}
