using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowExitButton : MonoBehaviour
{
    public GameObject optionsWindow;
    public void CloseWindow()
    {
        optionsWindow.SetActive(false);
    }

    public void OpenWindow()
    {
        optionsWindow.SetActive(true);
    }
}
