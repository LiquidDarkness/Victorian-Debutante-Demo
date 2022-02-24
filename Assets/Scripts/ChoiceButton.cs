using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] Button choiceButton;
    [SerializeField] Text choiceText;
    public DecisionAnimation decisionAnimation;
    public AfterChoiceAnimation afterChoice;
    public int index;
    public Text text;
    public GameObject rootGameObject;

    public void HandleChoiceMade()
    {
        decisionAnimation.ChooseDecision(index);
        afterChoice.PerformAnimation();
    }

    internal void SetText(string textToSet)
    {
        choiceText.text = textToSet;
    }
}
