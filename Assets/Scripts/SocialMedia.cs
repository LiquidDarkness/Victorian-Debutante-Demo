using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMedia : MonoBehaviour
{
    public string socialMediaURL;

    public void urlOpener()
    {
        Application.OpenURL(socialMediaURL);
    }
}
