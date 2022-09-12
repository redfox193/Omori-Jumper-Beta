using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBalance : MonoBehaviour
{
    public bool[] boughtThemes;
    public int chosenTheme;
    private void Start()
    {
        ThemeManager.boughtThemes = boughtThemes;
        ThemeManager.chosenTheme = chosenTheme;
    }
}
