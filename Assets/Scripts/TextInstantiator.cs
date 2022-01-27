using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInstantiator : MonoBehaviour
{
    public ChoiceButton choicePrefab;
    public Transform storyTextsContainer;
    public DecisionAnimation decisionAnimation;
    public AfterChoiceAnimation afterChoice;
    [NonSerialized, HideInInspector]
    public List<ChoiceButton> buttons = new List<ChoiceButton>();

    private ChoiceButton choiceButton;

    public void Awake()
    {
        InstantiateButtons();
    }

    [ContextMenu("Test Instantiate")]
    public void InstantiateButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            choiceButton = Instantiate(choicePrefab, storyTextsContainer);
            choiceButton.index = i;
            buttons.Add(choiceButton);
            choiceButton.decisionAnimation = decisionAnimation;
            choiceButton.afterChoice = afterChoice;
        }
    }
}
