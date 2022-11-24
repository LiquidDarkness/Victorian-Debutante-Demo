using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentSettings
{
    static List<int> intsToCache = new List<int>();
    static List<float> floatsToCache = new List<float>();
    static List<string> stringsToCache = new List<string>();
    static HashSet<string> intKeysToGrab = new HashSet<string>();
    static HashSet<string> floatKeysToGrab = new HashSet<string>();
    static HashSet<string> stringKeysToGrab = new HashSet<string>();

    public static void PurgePlayerPrefs()
    {
        CacheSettingsData();
        PlayerPrefs.DeleteAll();
        RestoreFromCache();
    }

    public static void PreservePlayerPref(TypeDistinguisher typeDistinguisher)
    {
        switch (typeDistinguisher.prefType)
        {
            case TypeDistinguisher.PlayerPrefType.INT:
                intKeysToGrab.Add(typeDistinguisher.PrefsKey);
                break;
            case TypeDistinguisher.PlayerPrefType.FLOAT:
                floatKeysToGrab.Add(typeDistinguisher.PrefsKey);
                break;
            case TypeDistinguisher.PlayerPrefType.STRING:
                stringKeysToGrab.Add(typeDistinguisher.PrefsKey);
                break;
            default:
                break;
        }
    }
    private static void CacheSettingsData()
    {
        intsToCache.Clear();
        floatsToCache.Clear();
        stringsToCache.Clear();

        foreach (string key in intKeysToGrab)
        {
            intsToCache.Add(PlayerPrefs.GetInt(key));
        }      
        foreach (string key in floatKeysToGrab)
        {
            floatsToCache.Add(PlayerPrefs.GetFloat(key));
        }        
        foreach (string key in stringKeysToGrab)
        {
            stringsToCache.Add(PlayerPrefs.GetString(key));
        }
       // valuesToCache.Add(PlayerPrefs.GetInt("A")); // 69
       // valuesToCache.Add(PlayerPrefs.GetInt("B")); // 42
    }

    private static void RestoreFromCache()
    {
        RestoreIntFromCache();
        RestoreFloatFromCache();
        RestoreStringFromCache();

       // PlayerPrefs.SetInt("A", valuesToCache[0]);
       // PlayerPrefs.SetInt("B", valuesToCache[1]);
    }

    private static void RestoreStringFromCache()
    {
        int index = 0;
        foreach (string key in stringKeysToGrab)
        {
            PlayerPrefs.SetString(key, stringsToCache[index]);
            index++;
        }
    }

    private static void RestoreFloatFromCache()
    {
        int index = 0;
        foreach (string key in floatKeysToGrab)
        {
            PlayerPrefs.SetFloat(key, floatsToCache[index]);
            index++;
        }
    }

    private static void RestoreIntFromCache()
    {
        int index = 0;
        foreach (string key in intKeysToGrab)
        {
            PlayerPrefs.SetInt(key, intsToCache[index]);
            index++;
        }
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
