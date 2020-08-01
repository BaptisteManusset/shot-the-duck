using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWeb : MonoBehaviour
{
    [SerializeField] string url;

    public void go()
    {
        Application.OpenURL(url);
    }
}
