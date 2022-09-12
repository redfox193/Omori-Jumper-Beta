using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    public Sprite volumeON;
    public Sprite volumeOFF;
    public static bool isVolumeON { get; private set; }

    private Image volumeImage;

    private void Start()
    {
        volumeImage = GetComponent<Image>();
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            volumeImage.sprite = volumeON;
            isVolumeON = true;
        }
        else
        {
            volumeImage.sprite = volumeOFF;
            isVolumeON = false;
        }
    }

    public void VolumeON()
    {
        isVolumeON = true;
        volumeImage.sprite = volumeON;
        PlayerPrefs.SetInt("Music", 1);
    }
    public void VolumeOFF()
    {
        isVolumeON = false;
        volumeImage.sprite = volumeOFF;
        PlayerPrefs.SetInt("Music", 0);
    }
}
