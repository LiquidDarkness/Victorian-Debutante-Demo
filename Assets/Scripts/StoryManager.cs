using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    private const string savedStoryKey = "savedStoryKey";
    public static Story firstStory;
    private static Story savedStory;
    public string storyName;
    public StoryDisplayer storyDisplayer;
    private Story currentStory;

    public static Story SavedStory { get => LoadSavedStory(); set => savedStory = value; }

    void Start()
    {
        currentStory = firstStory;
    }

    public void ProceedToNextStory()
    {
        if (currentStory.NextStory != null)
        {
            currentStory = LoadNextStory();
            savedStory = currentStory;
            SaveSavedStory(savedStory);
            storyDisplayer.DisplayStory(currentStory);
            return;
        }
    }

    private void SaveSavedStory(Story savedStory)
    {
        storyName = savedStory.name;
        PlayerPrefs.SetString(savedStoryKey, storyName);
    }

    private static Story LoadSavedStory()
    {
        string storyName = PlayerPrefs.GetString(savedStoryKey);
        return Resources.Load<Story>($"Stories/Stories/{storyName}");
        // TODO: magic string jest be, naprawiæ.
    }

    private Story LoadNextStory()
    {
        return currentStory.NextStory;
    }

    // TODO: dlaczego ³aduje siê placeholder zamiast story na dzieñdobry?
    // TODO: uproœciæ spuchniêty kod w tej klasie.
    
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
