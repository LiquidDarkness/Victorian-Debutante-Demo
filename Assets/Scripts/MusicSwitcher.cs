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
    public AnimationCurve testUp, testDown;


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
        timeElapsed = 0;
        float referenceTime = Time.realtimeSinceStartup;
        while (timeElapsed < fadeoutTime)
        {
            float targetVolume = Mathf.Lerp(0, 1, timeElapsed / fadeoutTime);
            audioSource.volume = testDown.Evaluate(targetVolume);
            timeElapsed = Time.realtimeSinceStartup - referenceTime;
            yield return null;
        }

        audioSource.clip = audioClip;
        timeElapsed = 0;
        yield return null;
        referenceTime = Time.realtimeSinceStartup;
        audioSource.Play();

        while (timeElapsed < fadeoutTime)
        {
            float targetVolume = Mathf.Lerp(0, 1, timeElapsed / fadeoutTime);
            audioSource.volume = testUp.Evaluate(targetVolume);
            timeElapsed = Time.realtimeSinceStartup - referenceTime;
            yield return null;
        }

    }

    public AudioClip testClip;
    [ContextMenu("Test Switching Audio")]
    public void TestSwitching()
    {
        SwitchAudio(testClip);
    }
}
