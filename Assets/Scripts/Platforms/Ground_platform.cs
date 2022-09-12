using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_platform : Platform
{
    public Player playerObject;
    public Transform spawnPosition;

    private void Awake()
    {
        spawnPosition.position = new Vector3(spawnPosition.position.x, spawnPosition.position.y, 0f);
        Instantiate(playerObject, spawnPosition.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        }
    }
}
