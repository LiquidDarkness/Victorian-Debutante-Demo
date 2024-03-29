using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startingClip;
    public float volumeDownBy;
    public float volumeUpBy;

    public void Start()
    {
        audioSource.clip = startingClip;
        audioSource.Play();
    }
    public void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    public void SwitchAudio(AudioClip audioClip)
    {
        StartCoroutine(SwitchAudioRoutine(audioClip));
    }

    private IEnumerator SwitchAudioRoutine(AudioClip audioClip)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= volumeDownBy;
            yield return null;
        }

        audioSource.clip = audioClip;
        yield return null;

        while (audioSource.volume < 1)
        {
            audioSource.volume += volumeUpBy;
            yield return null;
        }
    }

    public AudioClip testClip;
    [ContextMenu("Test Switching Audio")]
    public void TestSwitching()
    {
        SwitchAudio(testClip);
    }

    //TODO: W DOMU wywali� awake i zrobi� tak, �eby dzia�a�o na czas, nie na stepy(volumeUp/DownBy).
}
