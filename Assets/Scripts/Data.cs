using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static int screenWidth { get; private set; }
    public static int screenHeight { get; private set; }

    public static int record { get; private set; }
    public static int cash { get; private set; }

    public static void SetCashInData(int c)
    {
        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + c);
        cash = PlayerPrefs.GetInt("Cash");
    }

    public static void SetRecordInData(int r)
    {
        PlayerPrefs.SetInt("Record", Mathf.Max(PlayerPrefs.GetInt("Record"), r));
        record = PlayerPrefs.GetInt("Record");
    }

    private void Awake()
    {
        screenWidth = Screen.currentResolution.width;
        screenHeight = Screen.currentResolution.height;

        if (!PlayerPrefs.HasKey("NotFirstPlaying"))
        {
            PlayerPrefs.SetInt("ActiveTheme", 0);
            PlayerPrefs.SetInt("OmoriTheme", 0);
            PlayerPrefs.SetInt("Cash", 0);
            PlayerPrefs.SetInt("Record", 0);
            PlayerPrefs.SetString("NotFirstPlaying", "");
            PlayerPrefs.SetInt("Music", 1);
            record = PlayerPrefs.GetInt("Record");
            cash = PlayerPrefs.GetInt("Cash");
            ThemeManager.chosenTheme = 0;
            ThemeManager.boughtThemes[1] = false;
        }
        else
        {
            record = PlayerPrefs.GetInt("Record");
            cash = PlayerPrefs.GetInt("Cash");
            ThemeManager.chosenTheme = PlayerPrefs.GetInt("ActiveTheme");
            if (PlayerPrefs.GetInt("OmoriTheme") == 1)
                ThemeManager.boughtThemes[1] = true;
            else
                ThemeManager.boughtThemes[1] = false;
        }
    }
}
