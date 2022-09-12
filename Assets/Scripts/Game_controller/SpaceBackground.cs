using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBackground : MonoBehaviour
{
    public GameObject spaceBackground;

    private float spawnRange;
    private float currentSpawnPoint;
    private GameObject[] spaces;
    private bool flag;

    private void Start()
    {
        spawnRange = 11.2f;
        flag = true;
    }

    private void Update()
    {
        if(Background.currentLocation.area == Background.areas.space)
        {
            if (flag)
            {
                Instantiate(spaceBackground, new Vector3(0f, Background.currentLocation.beginHeight + 10f, 0.5f), Quaternion.identity);
                flag = false;
            }
            spaces = GameObject.FindGameObjectsWithTag("SpaceBG");
            if(spaces.Length != 0)
            {
                currentSpawnPoint = spaces[0].transform.position.y;
                for(int i = 1; i < spaces.Length; i++)
                    currentSpawnPoint = Mathf.Max(currentSpawnPoint, spaces[i].transform.position.y);
                if (currentSpawnPoint <= Player.instance.transform.position.y)
                    Instantiate(spaceBackground, new Vector3(0f, currentSpawnPoint + spawnRange, 0.5f), Quaternion.identity);
            }
        }
    }
}
