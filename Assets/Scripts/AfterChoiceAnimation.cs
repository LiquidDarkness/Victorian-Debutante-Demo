using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterChoiceAnimation : MonoBehaviour
{
    public LayoutElement fakeStoryLayouter, realStoryLayouter, separatorLayouter, spacerLayouter;
    public VerticalLayoutGroup contentLayouter;
    //   public LayoutElement realStoryLayouter;
    public RectTransform realStoryTransform;    
    public RectTransform separatorTransform;
    public GameObject responseText;
    public float speed;
    float FakeStoryHeight
    {
        get
        {
            return fakeStoryLayouter.preferredHeight;
        }
        set
        {
            fakeStoryLayouter.preferredHeight = value;
        }
    }

    [ContextMenu("Test SetUpAfterAnimation")]
    void SetUpAfterAnimation()
    {
        realStoryLayouter.ignoreLayout = false;
        FakeStoryHeight = 0;
        fakeStoryLayouter.ignoreLayout = true;
    }


    public void PerformAnimation()
    {
        IEnumerator routine = MovingRoutine();
        this.StartCoroutine(routine);
    }

    [ContextMenu("Test SetUpForAnimation")]
    void SetUpForAnimation()
    {
        realStoryLayouter.ignoreLayout = true;
        separatorLayouter.ignoreLayout = true;
        fakeStoryLayouter.ignoreLayout = false;
        FakeStoryHeight = realStoryTransform.rect.height;
    }

    [ContextMenu("Test MoveHeightBy")]
    void TestMoveHeightBy()
    {
        float myTestValue = 15;
        MoveHeightBy(50f);
        MoveHeightBy(2 * myTestValue);
        MoveHeightBy(50f);
        MoveHeightBy(1.5f);
    }

    [ContextMenu("Test TestAnimation")]
    void TestAnimation()
    {
        IEnumerator routine = MovingRoutine();
        this.StartCoroutine(routine);
    }
    

    void MoveHeightBy(float delta)
    {

        /* var position = realStoryTransform.anchoredPosition;
        position.y -= 50;
        realStoryTransform.anchoredPosition = position; */
        realStoryTransform.Translate(0, delta, 0);
        FakeStoryHeight -= delta;
    }


    IEnumerator MovingRoutine()
    {
        SetUpForAnimation();
        float step = speed / FakeStoryHeight;
        float separatorSpeed = speed / FakeStoryHeight;

        yield return null;
        while (FakeStoryHeight > -300)
        {
            MoveHeightBy(step);
            yield return null;
        }

        float paddingValue = contentLayouter.padding.top;
        while (paddingValue > 0)
        {
            MoveHeightBy(step);
            paddingValue -= step;
            yield return null;
        }
        spacerLayouter.ignoreLayout = true;
        responseText.SetActive(true);
    }
}
