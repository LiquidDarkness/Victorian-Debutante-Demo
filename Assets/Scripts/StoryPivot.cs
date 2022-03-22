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
    private List<int> endingPoints;
    private const string savingKey = "BaseEndingValuesKey";
        //"savingKey serves as key in PlayerPrefs.SetString alongside savingData";
    public override Story NextStory => GetResultingStory();

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
                return; // pêtla wykona siê tylko tyle razy, ile jest potrzebnych, ¿eby spe³niæ warunek ifa.
            }
        }
    }

    private void SaveEndingData()
    {
        // example:
        // 32,12,9,15
        string savingData = string.Join(separator.ToString(), endingPoints);
        PlayerPrefs.SetString(savingKey, savingData);
    }
}
