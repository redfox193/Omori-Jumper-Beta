using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBackGroundFoeGame : MonoBehaviour
{
    public GameObject skyBackground;

    private float spawnRange = 23f;
    private float currentSpawnPoint;
    private GameObject[] skies;
    private bool flag = true;

    private void Update()
    {
        if (Background.currentLocation.area == Background.areas.ground || Background.currentLocation.area == Background.areas.sky)
        {
            if (flag)
            {
                Instantiate(skyBackground, new Vector3(0f, Background.currentLocation.beginHeight, 0.5f), Quaternion.identity);
                flag = false;
            }
            skies = GameObject.FindGameObjectsWithTag("SkyGameBG");
            if (skies.Length != 0)
            {
                currentSpawnPoint = skies[0].transform.position.y;
                for (int i = 1; i < skies.Length; i++)
                    currentSpawnPoint = Mathf.Max(currentSpawnPoint, skies[i].transform.position.y);
                if (currentSpawnPoint <= Player.instance.transform.position.y)
                    Instantiate(skyBackground, new Vector2(0f, currentSpawnPoint + spawnRange), Quaternion.identity);
            }
        }
    }
}
