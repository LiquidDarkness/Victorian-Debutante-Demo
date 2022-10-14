using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class SteamAchievements
{
    //TODO: DONE zrobiæ consty na nazwy statów do aczków
    public const string EndingsReached = "endingsReached";
    public const string StoriesRead = "storiesRead";

    public static void UnlockAchievement(string id)
    {
        var achievement = new Steamworks.Data.Achievement(id);
        achievement.Trigger();

        Debug.Log($"Achievement {id} unlocked");
    }

    public static void ClearChievementStatus()
    {
        Steamworks.SteamUserStats.ResetAll(true);

        Debug.Log($"Achievements are cleared");
    }

   
    public static void StoriesReadCountUpper()
    {
        Steamworks.SteamUserStats.AddStat(StoriesRead, 1);
        Steamworks.SteamUserStats.StoreStats();
    }

    public static void EndingsReachedCountUpper()
    {
        Steamworks.SteamUserStats.AddStat(EndingsReached, 1);
        Steamworks.SteamUserStats.StoreStats();
    }

    public static void StoriesReadCounter()
    {
        switch (Steamworks.SteamUserStats.GetStatInt(StoriesRead))
        {
            case 5:
                UnlockAchievement("SEEN_5_STORIES");
                break;
            case 10:
                UnlockAchievement("SEEN_10_STORIES");
                break;
            case 15:
                UnlockAchievement("SEEN_15_STORIES");
                break;
            case 20:
                UnlockAchievement("SEEN_20_STORIES");
                break;
            case 25:
                UnlockAchievement("SEEN_25_STORIES");
                break;
            case 100:
                UnlockAchievement("SEEN_100_STORIES");
                break;
            default:
                break;
        }
    }

    public static void EndingsReachedCounter()
    {
        switch(Steamworks.SteamUserStats.GetStatInt(EndingsReached))
        {
            case 1:
                UnlockAchievement("REACHED_1_ENDING");
                break;
            case 2:
                UnlockAchievement("REACHED_2_ENDING");
                break;
            case 3:
                UnlockAchievement("REACHED_3_ENDING");
                break;
            case 4:
                UnlockAchievement("REACHED_4_ENDING");
                break;
            default:
                break;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void Init()
    {
        //PlayerPrefs.SetInt("storiesRead", storiesRead);
        try
        {
            Steamworks.SteamClient.Init(1878110);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        Debug.Log("Init's working");
    }


    private static void PrintYourName()
    {
        Debug.Log(Steamworks.SteamClient.Name);
    }

    private static void PrintFriends()
    {
        foreach(var friend in Steamworks.SteamFriends.GetFriends())
        {
            Debug.Log(friend.Name);
        }
    }

    static void Update()
    {
        Steamworks.SteamClient.RunCallbacks();    
    }

    private static void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
}
