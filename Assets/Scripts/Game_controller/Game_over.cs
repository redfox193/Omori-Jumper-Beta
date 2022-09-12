using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_over : MonoBehaviour
{
    public AudioSource collisionWithEnemy;
    private static AudioSource staticCollisionWithEnemy;

    public static float max_height { get; private set; }
    private static bool flag = false;
    public static void GameOver()
    {
        if (!flag)
        {
            flag = true;
            Data.SetRecordInData((int)(max_height + 5f));
            Player.instance.isDead = true;
            AudioManager.instance.gameOver = true;
            AudioManager.instance.musicForFirstTwoLocations.Stop();
            AudioManager.instance.musicForTheThirdLocation.Stop();
            if (VolumeButton.isVolumeON)
                staticCollisionWithEnemy.Play();
        }
    }

    private void Start()
    {
        staticCollisionWithEnemy = collisionWithEnemy;
        flag = false;
        max_height = Player.instance.transform.position.y;
    }

    private void FixedUpdate()
    {
        if (!Player.instance.isDead && !flag)
        {
            max_height = Mathf.Max(max_height, Player.instance.transform.position.y);
            if (max_height - Player.instance.transform.position.y > 10f)
                GameOver();
        }
    }
}
