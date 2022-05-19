using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] Text choiceText;
    public int index;
    public Text text;
    public GameObject rootGameObject;

    public event Action<int> OnChosen;

    [UsedImplicitly()]
    public void HandleChoiceMade()
    {
        OnChosen?.Invoke(index);
    }

    internal void SetText(string textToSet)
    {
        choiceText.text = textToSet;
    }
}
