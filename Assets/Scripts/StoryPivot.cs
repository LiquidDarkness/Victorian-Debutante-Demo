using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "LiquidDarkness/" + nameof(StoryPivot))]
public class StoryPivot : Story
{
    public const char separator = ',';
    public List<Story> stories = new List<Story>();
    [SerializeField, HideInInspector] private List<int> endingPoints = new List<int>();
    private const string savingKey = "BaseEndingValuesKey";
    //"savingKey serves as key in PlayerPrefs.SetString alongside savingData";
    public override Story NextStory => GetResultingStory();
    public bool isInitialized = false;

    public void Init()
    {
        isInitialized = true;
        if (PlayerPrefs.HasKey(savingKey))
        {
            string savingData = PlayerPrefs.GetString(savingKey);
            endingPoints = ConvertData(savingData);
            return;
        }
        endingPoints = new List<int>(stories.Count);

        // endingPoints.Insert(0, 0);
        // endingPoints.Insert(1, 0);
        // endingPoints.Insert(2, 0);
        // endingPoints.Insert(3, 0);
        for (int itemIndex = 0; itemIndex < stories.Count; itemIndex++)
        {
            endingPoints.Add(0);
        }
        Debug.Log("Endingpoints.Count:" + endingPoints.Count);
        Debug.Log("Endingpoints.Count:" + stories.Count);
    }

    private List<int> ConvertData(string savingData)
    {
        // 32,12,9,15
        string[] convertingResult;
        convertingResult = savingData.Split(separator);
        //int example = int.Parse("32");
        // Linq pracuje na kolekcji convertingResult (kolekcja stringów), nastêpnie 
        // wybiera osobno ka¿dy element podanejkolekcji,
        // konwertuje go na typ int, korzystaj¹c z funkcji int.Parse, nastêpnie
        // konwertuje otrzyman¹ kolekcjê do listy
        return convertingResult.Select(int.Parse).ToList();
        //return convertingResult;
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
        SteamAchievements.EndingsReachedCountUpper(); //tu wywala b³¹d
        return stories[highestEndingIndex];
    }

    public void AddEndingPoints(int value, Story endingStory)
    {
        if (!isInitialized)
        {
            Init();
        }
        //Debug.Log(endingStory.name);
        for (int i = 0; i < stories.Count; i++)
        {
            Story story = stories[i];

            if (story == endingStory)
            {
                //Debug.Log("Found story at " + i);
                //Steamworks.SteamUserStats.AddStat("endingsReached", 1);
                //Steamworks.SteamUserStats.StoreStats();
                endingPoints[i] += value;
                SaveEndingData();
                return; // the loop will be processed as many times as needed for the if condition to be met.
            }
        }
        Debug.Log("No ending found");
    }

    private void SaveEndingData()
    {
        // example:
        // 32,12,9,15
        string savingData = string.Join(separator.ToString(), endingPoints);
        PlayerPrefs.SetString(savingKey, savingData);
    }
}
