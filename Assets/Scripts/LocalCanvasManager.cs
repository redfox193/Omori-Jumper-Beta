using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCanvasManager : MonoBehaviour
{
    private static SpriteCahnger[] objects;

    private void Start()
    {
        objects = FindObjectsOfType<SpriteCahnger>();
    }

    public static void HideComponents()
    {
        foreach (var i in objects)
            i.gameObject.SetActive(false);
    }

    public static void ShowComponents()
    {
        foreach (var i in objects)
            i.gameObject.SetActive(true);
    }
}
