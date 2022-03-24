using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentSettings
{
    static List<int> valuesToCache;
    static HashSet<string> keysToGrab = new HashSet<string>();

    public static void PurgePlayerPrefs()
    {
        CacheSettingsData();
        PlayerPrefs.DeleteAll();
        RestoreFromCache();
    }

    public static void PreservePlayerPref(string key)
    {
        keysToGrab.Add(key);
    }
    private static void CacheSettingsData()
    {
        foreach (string key in keysToGrab)
        {
            valuesToCache.Add(PlayerPrefs.GetInt(key));
        }
       // valuesToCache.Add(PlayerPrefs.GetInt("A")); // 69
       // valuesToCache.Add(PlayerPrefs.GetInt("B")); // 42
    }
    private static void RestoreFromCache()
    {
        int index = 0;
        foreach (string key in keysToGrab)
        {
            PlayerPrefs.SetInt(key, valuesToCache[index]);
            index++;
        }
       // PlayerPrefs.SetInt("A", valuesToCache[0]);
       // PlayerPrefs.SetInt("B", valuesToCache[1]);
    }

    
    /* public static List<int> listaIntów;

    public static void TyruRyru(int doUsuniêcia) // 2
    {
        for (int i = 0; i < doUsuniêcia; i++)
        {
            listaIntów.RemoveAt(listaIntów.Count - 1);
        }
    }

    */
}
