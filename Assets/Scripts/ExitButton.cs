using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("The game has been closed.");
    }

}
