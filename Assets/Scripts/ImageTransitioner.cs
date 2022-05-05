using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageTransitioner : MonoBehaviour
{
    public Sprite firstSprite, secondSprite;
    Texture2D texture;
    public Image image;
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

    // Start is called before the first frame update
    void Start()
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

    private Color EvaluateLineColor(int x, int y)
    {
        float idealY = EvaluateLine(x);
        float diff = Mathf.Abs(y - idealY);
        return new Color(1, 0, 0, 1f - diff / thickness / texture.width);
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
                var lineColor = EvaluateLineColor(x, y);
                Color previousStoryPixel = previousStoryPixels[y * texture.width + x];
                Color currentStoryPixel = currentStoryPixels[y * texture.width + x];
                pixels[y * texture.width + x] = Color.Lerp(previousStoryPixel, currentStoryPixel, lineColor.a);
            }
        }
        texture.SetPixels(pixels);
        texture.Apply();
    }

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
