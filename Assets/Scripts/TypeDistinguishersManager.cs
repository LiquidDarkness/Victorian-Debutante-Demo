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

    //TODO: DONE clasa dla wszystkich typedistinguisherów. Na awaku przelecieæ przez ca³¹ listê, ¿eby sprawdziæ, czy maj¹ purgable na true, jeœli nie, wo³am preserveplayerprefs.
}
