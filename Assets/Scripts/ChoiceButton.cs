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

    // TODO: LOW PRIORITY Button should not know about decisionAnimation or Afterchoice.
    // To, co siê dzieje na scenie potrzebuje swojej klasy, która bêdzie tym wszystkim zarz¹dzaæ (GameplayDisplayManager, AnimationManager, ???)
    // Dziêki temu, bêdzie mo¿na wo³aæ rownie¿ SetupForDisplay i RestoreDecisions z poziomu kodu.
    // TODO: disabln¹æ buttonek do przechodzenia do nastêpnej story do momentu podjêcia decyzji (do klasy wy¿ej)
    // TODO: FadeOut obrazka Story do jakiegoœ fajnego fioletowego czy cuœ.
}
