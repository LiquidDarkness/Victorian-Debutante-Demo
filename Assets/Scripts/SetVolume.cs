using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer musicMixer;
    public Slider slider;
    public float mixerValue;
    public float properSliderValue;
    public TypeDistinguisher musicVolume;

    public void SetVolumeLevel (float sliderVolume)
    {
        mixerValue = Mathf.Log10(sliderVolume) * 20;
        musicMixer.SetFloat("MusicVolume", mixerValue);
        properSliderValue = slider.value;

        PlayerPrefs.SetFloat(musicVolume.PrefsKey, properSliderValue);
    }

    [RuntimeInitializeOnLoadMethod]
    public void Awake()
    {
        slider.value = PlayerPrefs.GetFloat(musicVolume.PrefsKey);
        Debug.Log("Setting volume:" + musicMixer.name + slider.value);
    }
}
