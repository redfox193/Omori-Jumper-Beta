using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithWeb : Platform
{
    public bool hidePlatform;

    private void Start()
    {
        hidePlatform = true;
        SpriteChanger();
    }
}
