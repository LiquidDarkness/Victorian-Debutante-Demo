using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPivot : Story
{
    public List<Story> stories;
    public List<int> endingPoints;

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
}
