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
    private string currentChosenStyle;
    private List<IEnumerator> enumerators = new List<IEnumerator>();
    private List<string> animationStyles = new List<string>();
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
        enumerators.Clear();
        enumerators.Add(DissolveImageAnimation());
        enumerators.Add(imageTransitioner.GlowLineAnimation());
        enumerators.Add(NoAnimation());
        //foreach (IEnumerator enumerator in enumerators)
        {
            animationStyles.Add(nameof(DissolveImageAnimation));
            animationStyles.Add(nameof(imageTransitioner.GlowLineAnimation));
            animationStyles.Add(nameof(NoAnimation));
        }
        animationStylesDropdown.AddOptions(animationStyles);
        currentChosenStyle = nameof(NoAnimation);
            //PlayerPrefs.GetString(animationStyle.PrefsKey);
    }

    public void SetAnimationStyle(int index)
    {
        currentChosenStyle = animationStyles[index];
        PlayerPrefs.SetString(animationStyle.PrefsKey, currentChosenStyle);
    }

    public void StartChosenAnimationStyle(Sprite storyImage)
    {
        //IEnumerator GlowLineAnimation = imageTransitioner.GlowLineAnimation();
        secondSprite = storyImage;
        firstSprite = storyImage;
        int index = animationStyles.IndexOf(currentChosenStyle);
        Debug.Log($"Index: {index}, {currentChosenStyle}");
        StartCoroutine(enumerators[index]);
        //StartCoroutine(useDissolveAnimation ? DissolveImageAnimation() : GlowLineAnimation);
    }

    private void StartCoroutine()
    {
        throw new NotImplementedException();
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
        yield return null;
    }

    IEnumerator NoAnimation()
    {
        image.sprite = secondSprite;
        firstSprite = secondSprite;
        yield break;
    }
//TODO: uproœciæ kod.
}
