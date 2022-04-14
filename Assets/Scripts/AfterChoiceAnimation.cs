using JetBrains.Annotations;
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

    [UsedImplicitly]
    [ContextMenu("Test SetUpAfterAnimation")]
    public void SetUpForDisplay()
    {
        FakeStoryHeight = 0;
        realStoryLayouter.ignoreLayout = false;
        spacerLayouter.ignoreLayout = false;
        separatorLayouter.ignoreLayout = false;
        fakeStoryLayouter.ignoreLayout = true;
        responseText.SetActive(false);
    }


    public void PerformAnimation()
    {
        IEnumerator routine = MovingRoutine();
        this.StartCoroutine(routine);
    }

    [ContextMenu("Test SetUpForAnimation")]
    void SetUpForAnimation()
    {
        float totalSeparationHeight = separatorTransform.rect.height + contentLayouter.spacing * 2;
        realStoryLayouter.ignoreLayout = true;
        spacerLayouter.ignoreLayout = true;
        separatorLayouter.ignoreLayout = true;
        fakeStoryLayouter.ignoreLayout = false;
        FakeStoryHeight = realStoryTransform.rect.height + totalSeparationHeight;
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
        while (FakeStoryHeight > 0)
        {
            MoveHeightBy(step);
            yield return null;
        }
        responseText.SetActive(true);
    }
}