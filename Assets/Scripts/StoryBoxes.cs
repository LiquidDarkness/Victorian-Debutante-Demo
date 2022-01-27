using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "StoryBox")]
public class StoryBoxes : ScriptableObject
{
    [TextArea(20, 10)]
    public string storyText;
    public Sprite storyImage;
}
