using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: najprawdopodobniej powinien wywp�ywa� te� endingi.
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

// To, co si� dzieje na scenie potrzebuje swojej klasy, kt�ra b�dzie tym wszystkim zarz�dza� (GameplayDisplayManager, AnimationManager, ???)
// Dzi�ki temu, b�dzie mo�na wo�a� rownie� SetupForDisplay i RestoreDecisions z poziomu kodu.
// TODO: disabln�� buttonek do przechodzenia do nast�pnej story do momentu podj�cia decyzji (do klasy wy�ej)