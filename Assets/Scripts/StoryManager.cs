using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public Story firstStory;
    public StoryDisplayer storyDisplayer;
    private Story currentStory;

    void Start()
    {
        currentStory = firstStory;
    }

    public void ProceedToNextStory()
    {
        if (currentStory.NextStory != null)
        {
            currentStory = LoadNextStory();
            storyDisplayer.DisplayStory(currentStory);
            return;
        }
    }

    private Story LoadNextStory()
    {
        return currentStory.NextStory;
    }

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
}
