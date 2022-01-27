using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DecisionAnimation : MonoBehaviour
{
    Text[] decisionTexts;
    GameObject[] decisions;
    public TextInstantiator textInstantiator;

    public void Start()
    {
        decisions = new GameObject[textInstantiator.buttons.Count];
        decisionTexts = textInstantiator.buttons.Select(button => button.text).ToArray();
        for (int i = 0; i < decisions.Length; i++)
        {
            decisions[i] = textInstantiator.buttons[i].rootGameObject;
        }
    }

    public void PerformAnimation()
    {
        IEnumerator routine = MovingRoutine();
        this.StartCoroutine(routine);
    }

    /// <summary>
    /// Fades out the three decision that weren't chosen by the player in the scene.
    /// </summary>
    [ContextMenu("Test FadeOutDecisions")]
    public void ChooseDecision(int decisionIndex)
    {
        for (int i = 0; i < decisions.Length; i++)
        {
            decisions[i].SetActive(false);
        }
        decisions[decisionIndex].SetActive(true);
    }

    [ContextMenu("Test FadeOutDecisions")]
    private void TestSelectDecisionB()
    {
        for (int i = 0; i < decisions.Length; i++)
        {
            decisions[i].SetActive(false);
        }
        decisions[1].SetActive(true);

        //Ta metoda symuluje klikniêcie opcji B przez gracza. Dodaæ tak¹ sam¹ testow¹ metodê dla A, C i D.
    }

    private static void FadeOutOneDecision(Text decisionText)
    {
        Color textColor = decisionText.color;
        textColor.a = 0;
        decisionText.color = textColor;
    }

    /// <summary>
    /// Moves up all the decision text until the chosen one is the headline.
    /// </summary>
    private void MoveUpDecisions()
    {

    }


    private IEnumerator MovingRoutine()
    {
        //FadeOutDecisions();
        yield return null;
        MoveUpDecisions();
    }
}

class Tester
{
    DecisionAnimation decisionAnimation;
    AfterChoiceAnimation choiceAnimation;
    private void Test()
    {
        choiceAnimation.PerformAnimation();
        decisionAnimation.PerformAnimation();
    }
}