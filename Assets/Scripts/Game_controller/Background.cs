using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Image image;
    public static Location currentLocation;
    public enum areas { ground, sky, space };
    public static readonly Location[] Locations = new[] 
    {
        new Location { area = areas.ground, beginHeight = -5f, endHeight = 49f},
        new Location { area = areas.sky, beginHeight = 30f, endHeight = 199f},
        new Location { area = areas.space, beginHeight = 200f, endHeight = 1000000f}
    };



    public struct Location
    {
        public areas area;
        public float beginHeight;
        public float endHeight;
    };

    private void Start()
    {
        currentLocation = Locations[0];
    }

    private void LocationChanger()
    {
        foreach (var l in Locations)
            if (Player.instance.transform.position.y >= l.beginHeight && Player.instance.transform.position.y <= l.endHeight)
                currentLocation = l;
    }

    private void Update()
    {
        LocationChanger();
    }
}