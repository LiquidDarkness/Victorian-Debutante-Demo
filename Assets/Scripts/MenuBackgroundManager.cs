using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackgroundManager : MonoBehaviour
{
    public List<Sprite> menuAlternatives;
    public Image menuBackground;
    private int endingsLoop;

    private void Awake()
    {
        Debug.Log("Whatever.");
        endingsLoop = Steamworks.SteamUserStats.GetStatInt(SteamAchievements.EndingsReached);
        ChangeMenuBackground();
    }

    void ChangeMenuBackground()
    {
        menuBackground.sprite = menuAlternatives[endingsLoop % menuAlternatives.Count];
    }

    void ResetMenuBackground()
    {
        endingsLoop = 0;
    }
}
