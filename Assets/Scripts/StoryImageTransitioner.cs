using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StoryImageTransitioner : MonoBehaviour
{
    public Image storyImage;
    [Range(0, 10)]
    public int maxThickness;
    private int lineThickness;
    public AnimationCurve xAnimation;
    public AnimationCurve thicknessAnimation;
    public float duration;
    private int xOffset;
    private int pixelAmount;
    private Texture2D texture2D;
    private Color[] clearPixels;
    
    // Start is called before the first frame update
    void Start()
    {
        texture2D = new Texture2D(108, 192);
        pixelAmount = texture2D.height * texture2D.width;
        clearPixels = Enumerable.Repeat<Color>(Color.clear, pixelAmount).ToArray();
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one / 2.0f);
        storyImage.sprite = sprite;
        StartCoroutine(LineAnimationRoutine());
    }

    private void PaintTexture()
    {
        texture2D.SetPixels(clearPixels);
        for (int i = 0; i < lineThickness; i++)
        {
            for (int line = 0; line < texture2D.height; line++)
            {
                texture2D.SetPixel(xOffset + i, line, Color.red);
            }
        }
        texture2D.Apply();
    }

    // Update is called once per frame
    IEnumerator LineAnimationRoutine()
    {
        float animationTime = 0;
        while (animationTime < duration)
        {
            float xOffsetPercent = xAnimation.Evaluate(animationTime / duration);
            xOffset = (int)(texture2D.width * xOffsetPercent);  
            float lineThicknessPercent = thicknessAnimation.Evaluate(xOffsetPercent);
            Debug.Log(lineThicknessPercent);
            lineThickness = (int)(maxThickness * lineThicknessPercent);
            PaintTexture();
            animationTime += Time.deltaTime;
            yield return null;
        }
    }

}
