using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioSource musicForMainMenu;
    public AudioSource musicForFirstTwoLocations;
    public AudioSource musicForTheThirdLocation;

    public AudioSource clickOnButton;

    public AudioSource clickOnResumeOrPlayButton;

    public AudioSource wrongClickOnButton;

    public AudioSource themeChangeClick;

    public AudioSource clickOnYesOrNoButton;

    public AudioSource playerChangingWithSwipe;

    public bool gameOver = false;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Audio").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void BGMusic()
    {
        if (VolumeButton.isVolumeON)
        {
            if (SceneManager.GetActiveScene().name != "Main")
            {
                if (musicForFirstTwoLocations.isPlaying || musicForTheThirdLocation.isPlaying)
                {
                    musicForFirstTwoLocations.Stop();
                    musicForTheThirdLocation.Stop();
                }
                if (!musicForMainMenu.isPlaying)
                    musicForMainMenu.Play();
            }
            else if (SceneManager.GetActiveScene().name == "Main")
            {
                if (!musicForFirstTwoLocations.isPlaying && !musicForTheThirdLocation.isPlaying && !gameOver)
                {
                    musicForMainMenu.Stop();
                    musicForFirstTwoLocations.Play();
                }
                else if (Background.currentLocation.area == Background.areas.space && !musicForTheThirdLocation.isPlaying && !gameOver)
                {
                    musicForFirstTwoLocations.Stop();
                    musicForTheThirdLocation.Play();
                }
            }
        }
        else if (musicForMainMenu.isPlaying || musicForFirstTwoLocations.isPlaying || musicForTheThirdLocation.isPlaying)
        {
            musicForMainMenu.Stop();
            musicForFirstTwoLocations.Stop();
            musicForTheThirdLocation.Stop();
        }

    }

    void Update()
    {
        BGMusic();
    }

    public void ClickOnButton()
    {
        if (VolumeButton.isVolumeON)
            clickOnButton.Play();
    }

    public void ClickOnResumeOrPlayButton()
    {
        if (VolumeButton.isVolumeON)
            clickOnResumeOrPlayButton.Play();
    }

    public void WrongClickOnButton()
    {
        if (VolumeButton.isVolumeON)
            wrongClickOnButton.Play();
    }

    public void ThemeChangeClick()
    {
        if (VolumeButton.isVolumeON)
            themeChangeClick.Play();
    }

    public void ClickOnYesOrNoButton()
    {
        if (VolumeButton.isVolumeON)
        {
            gameOver = false;
            clickOnYesOrNoButton.Play();
        }
        else
            gameOver = false;
    }

    public void PlayerChangingWithSwipe()
    {
        if (VolumeButton.isVolumeON)
            playerChangingWithSwipe.Play();
    }
}
