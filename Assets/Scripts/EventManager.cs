using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    private void OnGUI()
    {
        if (OnClicked != null)
        {
            OnClicked();
        }
    }
    // public static Action OnChoiceMade;
    // public static Action OnContinueClicked;
}
