using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startingClip;
    public float fadeoutTime;
    public float timeElapsed = 0;

    public void Start()
    {
        audioSource.clip = startingClip;
        audioSource.Play();
    }

    public void SwitchAudio(AudioClip audioClip)
    {
        StartCoroutine(SwitchAudioRoutine(audioClip));
    }

    private IEnumerator SwitchAudioRoutine(AudioClip audioClip)
    {
        while (timeElapsed < fadeoutTime)
        {
            audioSource.volume = Mathf.Lerp(1, 0, timeElapsed / fadeoutTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        audioSource.clip = audioClip;
        timeElapsed = 0;
        yield return null;

        while (timeElapsed < fadeoutTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1, timeElapsed / fadeoutTime);
            timeElapsed += Time.deltaTime;
            audioSource.Play();
            yield return null;
        }

    }

    public AudioClip testClip;
    [ContextMenu("Test Switching Audio")]
    public void TestSwitching()
    {
        SwitchAudio(testClip);
    }

    //TODO: W DOMU wywaliæ awake i zrobiæ tak, ¿eby dzia³a³o na czas, nie na stepy(volumeUp/DownBy).
}
