using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ChoiceBox")]
public class ChoiceBoxes : ScriptableObject
{
    [SerializeField] Button choiceA;
    [SerializeField] Button choiceB;
    [SerializeField] Button choiceC;
    [SerializeField] Button choiceD;
}
