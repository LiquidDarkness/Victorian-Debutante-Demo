using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageTransitioner : MonoBehaviour
{
    [SerializeField] Sprite firstSprite, secondSprite;
    Texture2D texture;
    public Image image;
    public Color glowColor;
    [Range(0,360)]
    public float angle;
    [Range(-1, 1)]
    public float yoffset;
    [Range(0, 1)]
    public float thickness;
    public AnimationCurve xAnimation;
    public AnimationCurve thicknessAnimation;
    public float duration;
    Color[] pixels;
    private Color[] previousStoryPixels;
    private Color[] currentStoryPixels;

    public Sprite FirstSprite
    {
        set 
        { 
            firstSprite = value;
            image.sprite = firstSprite;
        }
    }

    void TransitionInit()
    {
        texture = new Texture2D(firstSprite.texture.width, secondSprite.texture.height);
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2f);
        pixels = new Color[texture.width * texture.height];
        previousStoryPixels = firstSprite.texture.GetPixels();
        currentStoryPixels = secondSprite.texture.GetPixels();
        texture.SetPixels(previousStoryPixels);
        texture.Apply();

        PaintTexture();
    }

    private float EvaluateLineAlpha(int x, int y, out bool isAboveLine)
    {
        float idealY = EvaluateLine(x);
        float diff = Mathf.Abs(y - idealY);
        isAboveLine = y > idealY;
        return 1f - diff / thickness / texture.width;
    }

    private float EvaluateLine(int x)
    {
        float a = Mathf.Tan(angle * Mathf.Deg2Rad);
        float idealY =  a * x + yoffset * texture.height;
        return idealY;
    }

    private void PaintTexture()
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                int singleDimensionalIndex = y * texture.width + x;
                var lineAplha = EvaluateLineAlpha(x, y, out bool isAboveLine);
                Color currentStoryPixel = currentStoryPixels[singleDimensionalIndex];
                if (!isAboveLine)
                {
                    pixels[singleDimensionalIndex] = Color.Lerp(currentStoryPixel, glowColor, lineAplha);
                    continue;
                }
                Color previousStoryPixel = previousStoryPixels[singleDimensionalIndex];
                Color pixel = Color.Lerp(previousStoryPixel, currentStoryPixel, lineAplha);
                pixels[singleDimensionalIndex] = Color.Lerp(pixel, glowColor, lineAplha);
            }
        }
        texture.SetPixels(pixels);
        texture.Apply();
    }

    [ContextMenu("Test")]
    public void StartLineAnimation(Sprite storyImage)
    {
        secondSprite = storyImage;
        TransitionInit();
        firstSprite = storyImage;
        StartCoroutine(GlowLineAnimation());
    }

    public IEnumerator GlowLineAnimation()
    {
        //yield break;
        float animationTime = 0;
        while (animationTime < duration)
        {
            PaintTexture(animationTime);
            animationTime += Time.deltaTime;
            yield return null;
        }
        PaintTexture(duration);

        void PaintTexture(float animationTime)
        {
            yoffset = xAnimation.Evaluate(animationTime / duration);
            thickness = thicknessAnimation.Evaluate(yoffset);
            this.PaintTexture();
        }
    }
}
