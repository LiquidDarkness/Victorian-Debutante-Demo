using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: najprawdopodobniej powinien wywp³ywaæ te¿ endingi.
public class GameplayDisplayManager : MonoBehaviour
{
    public DecisionAnimation decisionAnimation;
    public AfterChoiceAnimation afterChoiceAnimation;
    public Button continueButton;
    public TextInstantiator textInstantiator;
    public StoryManager storyManager;
    public StoryPivot storyPivot;

    public void Start()
    {
        foreach (var choiceButton in textInstantiator.buttons)
        {
            choiceButton.OnChosen += HandleChoiceMade;
        }
        continueButton.onClick.AddListener(HandleContinueButtonClicked);
        storyPivot.Init();
    }
    public void HandleChoiceMade(int index)
    {
        List<Story.PointsData> choiceEndingsData = storyManager.currentStory.pivotsData[index].pointsData;
        foreach (var item in choiceEndingsData)
        {
            storyPivot.AddEndingPoints(item.points, item.story);
        }
        decisionAnimation.ChooseDecision(index);
        afterChoiceAnimation.PerformAnimation();
        continueButton.interactable = true;
    }

    private void HandleContinueButtonClicked()
    {
        continueButton.interactable = false;
    }
}

// To, co siê dzieje na scenie potrzebuje swojej klasy, która bêdzie tym wszystkim zarz¹dzaæ (GameplayDisplayManager, AnimationManager, ???)
// Dziêki temu, bêdzie mo¿na wo³aæ rownie¿ SetupForDisplay i RestoreDecisions z poziomu kodu.
// TODO: disabln¹æ buttonek do przechodzenia do nastêpnej story do momentu podjêcia decyzji (do klasy wy¿ej)