using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Sprite otherWorldPlatform;
    public enum platformTypes { standart, webPlatform, ghostPlatform };
    public int chance;
    public bool[] isActiveInDifferentLocations;

    protected void SpriteChanger()
    {
        if (Background.Locations[2].beginHeight - 10f < transform.position.y)
            GetComponent<SpriteRenderer>().sprite = otherWorldPlatform;
    }
}
