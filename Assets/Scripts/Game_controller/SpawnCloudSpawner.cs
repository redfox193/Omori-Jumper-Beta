using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloudSpawner : MonoBehaviour
{
    public GameObject cloudSpawner;

    private float posFromBorderX = 3f;
    private Background background;
    private CameraSize cameraSize;
    private Player player;
    private int previousYSpawn = -1;
    private int ySpawn = 0;
    private int firstYSpawn = 3;
    private int lastYSpawn = 17;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        cameraSize = GameObject.FindObjectOfType<CameraSize>();
        background = GameObject.FindObjectOfType<Background>();
    }

    private void Update()
    {
         ySpawn = (int)player.transform.position.y / 10;
         if (ySpawn > previousYSpawn && ySpawn < lastYSpawn)
         {
             Instantiate(cloudSpawner, new Vector3(cameraSize.borderX - posFromBorderX, (ySpawn + firstYSpawn) * 10, 1f), Quaternion.identity);
             previousYSpawn = ySpawn;
         }
    }
}
