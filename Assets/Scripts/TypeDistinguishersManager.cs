using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDistinguishersManager : MonoBehaviour
{
    public List<TypeDistinguisher> typeDistinguishers;

    private void Awake()
    {
        foreach (TypeDistinguisher item in typeDistinguishers)
        {
            if (! item.purgable)
                PersistentSettings.PreservePlayerPref(item);
        }
    }
}
