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
    // To, co si� dzieje na scenie potrzebuje swojej klasy, kt�ra b�dzie tym wszystkim zarz�dza� (GameplayDisplayManager, AnimationManager, ???)
    // Dzi�ki temu, b�dzie mo�na wo�a� rownie� SetupForDisplay i RestoreDecisions z poziomu kodu.
    // TODO: disabln�� buttonek do przechodzenia do nast�pnej story do momentu podj�cia decyzji (do klasy wy�ej)
    // TODO: FadeOut obrazka Story do jakiego� fajnego fioletowego czy cu�.
}
