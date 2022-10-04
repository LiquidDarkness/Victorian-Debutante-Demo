using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer musicMixer;

    public void SetVolumeLevel (float sliderVolume)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderVolume) * 20);
    }

    public void SaveVolumeLevel()
    {
        PersistentSettings.PreservePlayerPref(musicMixer.name);
    }

    //TODO: save slider's value in persistentsettings. save by the mixer's name, yay.
}
