using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeScript : MonoBehaviour
{
    public int id;
    public GameObject buyButton;
    public GameObject chosenButton;
    public GameObject notChosenButton;

    private void Update()
    {
        if(ThemeManager.boughtThemes[id])
        {
            buyButton.SetActive(false);
            if (ThemeManager.chosenTheme == id)
            {
                chosenButton.SetActive(true);
                notChosenButton.SetActive(false);
            }
            else
            {
                chosenButton.SetActive(false);
                notChosenButton.SetActive(true);
            }
        }
        else
        {
            buyButton.SetActive(true);
            chosenButton.SetActive(false);
            notChosenButton.SetActive(false);
        }
    }
}
