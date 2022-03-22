using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButton : MonoBehaviour
{
    public GameObject targetWindow;
    public void CloseWindow()
    {
        targetWindow.SetActive(false);
    }

    public void OpenWindow()
    {
        targetWindow.SetActive(true);
    }
}
