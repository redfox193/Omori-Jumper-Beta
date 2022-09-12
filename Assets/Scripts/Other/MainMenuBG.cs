using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBG : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().SetInteger("Theme", ThemeManager.chosenTheme);
    }
}
