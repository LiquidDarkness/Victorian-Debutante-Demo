using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class TransitionAnimationAlternative : MonoBehaviour
{
    [SerializeField] Sprite firstSprite, secondSprite;
    public TypeDistinguisher animationStyle;
    public ImageTransitioner imageTransitioner;
    public Image image;
    public float timeOfDissolve;
    public float goalAlphaValue;
    public bool ignoreTimeScale;
    public bool useDissolveAnimation;
    public Dropdown animationStylesDropdown;
    private int currentChosenIndex;
    private List<KeyValuePair<string, Action>> animationTypes;

    public Sprite FirstSprite
    {
        set
        {
            firstSprite = value;
            image.sprite = firstSprite;
        }
    }

    void Start()
    {
        animationStylesDropdown.ClearOptions();
        animationTypes = new List<KeyValuePair<string, Action>>();
        animationTypes.Add(new KeyValuePair<string, Action>("Dissolve", PlayDissolveAnimation));
        animationTypes.Add(new KeyValuePair<string, Action>("Glow", GlowLineAnimation));
        animationTypes.Add(new KeyValuePair<string, Action>("No animation", NoAnimation));
        Debug.Log(animationTypes.Count);
        animationStylesDropdown.AddOptions(animationTypes.Select(e => e.Key).ToList());
        //currentChosenStyle;
            //PlayerPrefs.GetString(animationStyle.PrefsKey);
    }

    public void SetAnimationStyle(int index)
    {
        currentChosenIndex = index;
        PlayerPrefs.SetInt(animationStyle.PrefsKey, currentChosenIndex);
    }

    public void StartChosenAnimationStyle(Sprite storyImage)
    {
        //IEnumerator GlowLineAnimation = imageTransitioner.GlowLineAnimation();
        secondSprite = storyImage;
        firstSprite = storyImage;
        Debug.Log($"Index: {currentChosenIndex}");
        animationTypes[currentChosenIndex].Value();
        //StartCoroutine(useDissolveAnimation ? DissolveImageAnimation() : GlowLineAnimation);
    }

    IEnumerator DissolveImageAnimation()
    {
        float duration = 0;
        image.CrossFadeAlpha(0, timeOfDissolve, ignoreTimeScale);
        while (duration < timeOfDissolve)
        {
            duration += Time.deltaTime;
            yield return null;
        }
        image.sprite = secondSprite;
        image.CrossFadeAlpha(1, timeOfDissolve, ignoreTimeScale);
        firstSprite = secondSprite;
    }

    void PlayDissolveAnimation()
    {
        StartCoroutine(DissolveImageAnimation());
    }

    void NoAnimation()
    {
        image.sprite = secondSprite;
        firstSprite = secondSprite;
    }

    void GlowLineAnimation()
    {
        imageTransitioner.StartLineAnimation(secondSprite);
    }
}
