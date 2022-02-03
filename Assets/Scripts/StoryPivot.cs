using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPivot : Story
{
    public List<Story> stories;
    private List<int> endingPoints;
    private const string savingKey = "savingKey serves as key in PlayerPrefs.SetString alongside savingData";

    public void Awake()
    {
        if (PlayerPrefs.HasKey(savingKey))
        {
            string savingData = PlayerPrefs.GetString(savingKey);
            endingPoints = ConvertData(savingData);
            return;
        }
        endingPoints = new List<int>(stories.Count);
    }

    private List<int> ConvertData(string savingData)
    {
        // TODO: odtegowaæ do listy
    }

    public Story GetResultingStory()
    {
        int highestEndingValue = 0;
        int highestEndingIndex = 0;

        for (int index = 0; index < endingPoints.Count; index++)
        {
            int item = endingPoints[index];
            if (item > highestEndingValue)
            {
                highestEndingValue = item;
                highestEndingIndex = index;
            }
        }

        return stories[highestEndingIndex];
    }

    public void AddEndingPoints(int value, Story endingStory)
    {
        for (int i = 0; i < stories.Count; i++)
        {
            Story story = stories[i];

            if (story == endingStory)
            {
                endingPoints[i] += value;
                SaveEndingData();
                return; // TODO: wykombinowaæ, po co tu jest ten return i co siê mo¿e staæ bez niego
            }
        }
    }

    private void SaveEndingData()
    {
        // example:
        // 32,12,9,15
        string savingData = string.Join(",", endingPoints);
        PlayerPrefs.SetString(savingKey, savingData);
    }
}
