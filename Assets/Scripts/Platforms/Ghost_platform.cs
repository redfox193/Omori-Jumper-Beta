using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_platform : Platform
{
    public void Appear()
    {
        GetComponent<Platform_for_jumping>().ghostHide = false;
    }

    public void Disappear()
    {
        GetComponent<Platform_for_jumping>().ghostHide = true;
    }

}
