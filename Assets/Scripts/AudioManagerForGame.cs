using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerForGame : MonoBehaviour
{
    public static AudioManagerForGame instance { get; private set; }

    public AudioSource musicForFirstTwoLocations;
    public AudioSource musicForTheThirdLocation;

    public AudioSource clickOnButton;

    public AudioSource clickOnResumeOrPlayButton;

    public AudioSource clickOnYesOrNoButton;

    void Start()
    {
    }

    private void BGMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
            if (Background.currentLocation.area == Background.areas.space && !musicForTheThirdLocation.isPlaying)
            {
                musicForFirstTwoLocations.Stop();
                musicForTheThirdLocation.Play();
            }
    }



    public void ClickOnButton()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
            clickOnButton.Play();
    }

    public void ClickOnResumeOrPlayButton()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
            clickOnResumeOrPlayButton.Play();
    }

    public void ClickOnYesOrNoButton()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            clickOnYesOrNoButton.Play();
        }
    }
}
