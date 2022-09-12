using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public VolumeButton volume;

    public void Play()
    {
        AudioManager.instance.ClickOnResumeOrPlayButton();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        AudioManager.instance.ClickOnButton();
        Application.Quit();
    }

    public void Themes()
    {
        AudioManager.instance.ClickOnButton();
        SceneManager.LoadScene(2);
    }
    public void Help()
    {
        AudioManager.instance.ClickOnButton();
        SceneManager.LoadScene(3);
    }

    public void Volume()
    {
        AudioManager.instance.ClickOnButton();
        if (VolumeButton.isVolumeON)
            volume.VolumeOFF();
        else
            volume.VolumeON();
    }
}
