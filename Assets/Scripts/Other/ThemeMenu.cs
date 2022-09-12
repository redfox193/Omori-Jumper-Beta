using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeMenu : MonoBehaviour
{
    public GameObject adsPanel;
    public Animation[] themesAnimation;
    private int[] themePrices = { 0, 1000 };

    public void BackToMenu()
    {
        AudioManager.instance.ClickOnButton();
        SceneManager.LoadScene(0);
    }

    public void Chose(int id)
    {
        if (ThemeManager.chosenTheme == id)
            AudioManager.instance.WrongClickOnButton();
        else
        {
            AudioManager.instance.ThemeChangeClick();
            ThemeManager.chosenTheme = id;
            PlayerPrefs.SetInt("ActiveTheme", id);
            themesAnimation[id].Play("ThemeClick");
        }
    }

    public void Buy(int id)
    {
        if (Data.cash >= themePrices[id])
        {
            Data.SetCashInData(-themePrices[id]);
            ThemeManager.boughtThemes[id] = true;
            PlayerPrefs.SetInt("OmoriTheme", 1);
            ThemeManager.chosenTheme = id;
            themesAnimation[id].Play("ThemeClick");
            AudioManager.instance.ThemeChangeClick();
        }
        else
            AudioManager.instance.WrongClickOnButton();
    }

    public void OpenAdsPanel()
    {
        AudioManager.instance.ClickOnButton();
        adsPanel.SetActive(true);
    }

    public void CloseAdsPanel()
    {
        AudioManager.instance.ClickOnButton();
        adsPanel.SetActive(false);
    }
}
