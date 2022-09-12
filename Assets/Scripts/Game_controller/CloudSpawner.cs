using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float spawnPointRange;
    public int spawnPointNumber;
    public GameObject[] clouds;
    public float spawnRange;
    public float spawnFrequency;

    private Vector3[] points;
    private float spawnY;

    IEnumerator Spawner(Vector3 position)
    {
        while (true)
        {
            position = new Vector3(position.x, position.y + Random.Range(-spawnPointRange / 2, spawnPointRange / 2), 1f);
            Instantiate(clouds[Random.Range(0, clouds.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    private void Start()
    {
        spawnY = transform.position.y - spawnRange / 2;
        points = new Vector3[spawnPointNumber];
        for(int i = 0; i < points.Length; i++)
        {
            spawnY += spawnRange / spawnPointNumber;
            points[i] = new Vector3(transform.position.x, spawnY, 1f);
        }
        for (int i = 0; i < points.Length; i++)
        {
            StartCoroutine("Spawner", points[i]);
        }
    }
}
