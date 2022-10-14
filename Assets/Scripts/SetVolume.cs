using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer musicMixer;
    public float sliderValue;
    public TypeDistinguisher musicVolume;

    public void SetVolumeLevel (float sliderVolume)
    {
        sliderValue = Mathf.Log10(sliderVolume) * 20;
        musicMixer.SetFloat("MusicVolume", sliderValue);

        PersistentSettings.PreservePlayerPref(musicVolume);
        PlayerPrefs.SetFloat(musicVolume.PrefsKey, sliderValue);
    }
    //TODO: wczyta� zapisan� warto�� z playerprefs�w na pocz�tku gry
    //TODO: wymysli� spos�b, �eby warto�ci z playerprefs�w wczytywa� na pocz�tku gry
    //TODO: save slider's value in persistentsettings. save by the mixer's name, yay.
}
