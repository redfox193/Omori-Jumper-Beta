using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    public AudioSource gameOverAudio;
    void Start()
    {
        Invoke("Begin", 3f);
    }

    private void Begin()
    {
        if(VolumeButton.isVolumeON)
            gameOverAudio.Play();
    }
}
