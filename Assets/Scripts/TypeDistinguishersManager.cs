using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDistinguishersManager : MonoBehaviour
{
    public List<TypeDistinguisher> typeDistinguishers;

    private void Awake()
    {
        if (typeDistinguishers != null)
            foreach (TypeDistinguisher item in typeDistinguishers)
            {
                if (item.purgable == false)
                    PersistentSettings.PreservePlayerPref(item);
            }
    }

    //TODO: DONE clasa dla wszystkich typedistinguisher�w. Na awaku przelecie� przez ca�� list�, �eby sprawdzi�, czy maj� purgable na true, je�li nie, wo�am preserveplayerprefs.
}
