using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StoryImageTransitioner : MonoBehaviour
{
    public Image glossImage;
    public Image storyImage;
    public Sprite previousStoryImage;
    public Sprite currentStoryImage;
    [Range(0, 10)] 
    public float maxGlossThickness;
    //public float antyaliasingThickness;
    [Range(0, 360)]
    public float angle;
    public AnimationCurve xAnimation;
    public AnimationCurve thicknessAnimation;
    public float duration;
    private float lineThickness;
    public int yOffset;
    private int pixelAmount;
    private int storyPixelAmount;
    private Texture2D glossTexture2D;
    private Texture2D storyTexture;
    private Color[] clearPixels;
    private Color[] previousStoryPixels;
    private Color[] currentStoryPixels;

    // Start is called before the first frame update
    void Start()
    {
        glossTexture2D = new Texture2D(102, 124);
        pixelAmount = glossTexture2D.height * glossTexture2D.width;
        clearPixels = Enumerable.Repeat<Color>(Color.clear, pixelAmount).ToArray();
        Sprite glossSprite = Sprite.Create(glossTexture2D, new Rect(0, 0, glossTexture2D.width, glossTexture2D.height), Vector2.one / 2.0f);
        glossImage.sprite = glossSprite;

        storyTexture = new Texture2D(previousStoryImage.texture.width, previousStoryImage.texture.height);
        Sprite storySprite = Sprite.Create(storyTexture, previousStoryImage.rect, previousStoryImage.pivot);
        storyImage.sprite = storySprite;
        previousStoryPixels = previousStoryImage.texture.GetPixels();
        currentStoryPixels = currentStoryImage.texture.GetPixels();
        storyPixelAmount = previousStoryPixels.Length;
        storyTexture.SetPixels(previousStoryPixels);
        storyTexture.Apply();

        StartCoroutine(LineAnimationRoutine());
    }

    private void PaintTexture()
    {
        Color[] glossColors = new Color[pixelAmount];
        Color[] storyColors = new Color[storyPixelAmount];

        for (int x = 0; x < glossTexture2D.width; x++)
        {
            for (int y = 0; y < glossTexture2D.height; y++)
            {
                glossColors[y * glossTexture2D.width + x] = EvaluateLine(x, y, glossTexture2D.height);
            }
        }

        glossTexture2D.SetPixels(glossColors);
        glossTexture2D.Apply();

        //TODO: Tu mi wywala b³¹dzik i tbh, nie pamiêtam, dlaczego zrobiliœmy to, co zrobiliœmy xd
        //return; 

        for (int x = 0; x < storyTexture.width; x++)
        {
            for (int y = 0; y < storyTexture.height; y++)
            {
                var lineColor = EvaluateLine(x, y, storyTexture.height);
                Color previousStoryPixel = previousStoryPixels[y * storyTexture.width + x];
                Color currentStoryPixel = currentStoryPixels[y * storyTexture.width + x];
                storyColors[y * storyTexture.width + x] = Color.Lerp(previousStoryPixel, currentStoryPixel, lineColor.a);
            }
        }
        storyTexture.SetPixels(storyColors);
        storyTexture.Apply();
    }

    private Color EvaluateLine(int x, int y, int sizeMultiplier)
    {
        float idealY = Mathf.Tan(angle * Mathf.Deg2Rad) * x + (yOffset * sizeMultiplier);
        float differenceFromIdeal = Mathf.Abs(y - idealY);
        float alphaValue = 1f - differenceFromIdeal / lineThickness / sizeMultiplier;
       // alphaValue = Mathf.InverseLerp(lineThickness + antyaliasingThickness, 0, differenceFromIdeal);
        return new Color(1f, 0f, 0f, alphaValue);
    }

    // Update is called once per frame
    [ContextMenu("Test")]
    private void Test()
    {
        StartCoroutine(LineAnimationRoutine());
    }
    IEnumerator LineAnimationRoutine()
    {
        float animationTime = 0;
        while (animationTime < duration)
        {
            float xOffsetPercent = xAnimation.Evaluate(animationTime / duration);
            yOffset = (int)(glossTexture2D.width * xOffsetPercent);  
            float lineThicknessPercent = thicknessAnimation.Evaluate(xOffsetPercent);
            Debug.Log(lineThicknessPercent);
            lineThickness = (maxGlossThickness * lineThicknessPercent);
            PaintTexture();
            animationTime += Time.deltaTime;
            yield return null;
        }
    }
}
