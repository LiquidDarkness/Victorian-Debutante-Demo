using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationChooser : MonoBehaviour
{
    [SerializeField] Sprite firstSprite, secondSprite;
    public TypeDistinguisher animationStyle;
    public StoryManager storyManager;
    public GameObject dissolveAnimator;
    public Image image;

    public Sprite FirstSprite
    {
        set
        {
            firstSprite = value;
            image.sprite = firstSprite;
        }
    }

    public void StartLineAnimation(Sprite storyImage)
    {
        secondSprite = storyImage;
        firstSprite = storyImage;
        StartCoroutine(NoImageAnimation());
    }

    IEnumerator NoImageAnimation()
    {
        image.sprite = secondSprite;
        firstSprite = secondSprite;
        yield break;
    }
}
