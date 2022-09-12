using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Builder : MonoBehaviour
{
    public Platform[] platform;
    public Enemy[] enemies;
    public Ground_platform groundPlatform;

    private enum Random_type { enemy, platform };
    private CameraSize mainCamera;

    private int chance;
    private int currentChance;
    private Vector3 position;
    private int type;

    //спавн платформ
    private const int numberOfDefaultPlatforms = 5;
    private float minRange = 1.8f;
    private float maxRange = 2f;
    private float maxSpawnHeight = 5f;
    private float currentSpawnHeight = -2f;
    private int platformSpawnChance = 0;
    private int extraPlatformChance = 55;

    //спавн монстров
    private float maxMobSpawnHeight = 15f;
    private float currentMobSpawnHeight;
    private float minMobRange = 7f;
    private float maxMobRange = 9f;
    private const int sumOfSpawnChances = 100;


    void Awake()
    {
        Vector2 position = new Vector3(0f, -5f, 0f);
        Instantiate(groundPlatform, position, Quaternion.identity);
        mainCamera = GameObject.FindObjectOfType<CameraSize>();
    }

    private void Start()
    {
        mainCamera = GameObject.FindObjectOfType<CameraSize>();
        groundPlatform = GameObject.FindObjectOfType<Ground_platform>();
        currentMobSpawnHeight = 4f + Random.Range(-2f, 2f);
        if (Random.Range(0, 100) < 65)
            Instantiate(enemies[0], new Vector3(0f, currentMobSpawnHeight, 0f), Quaternion.identity);
        currentMobSpawnHeight += Random.Range(minMobRange, maxMobRange);
        Instantiate(platform[0], new Vector3(Random.Range(mainCamera.borderX + 0.3f, -mainCamera.borderX - 0.3f), currentSpawnHeight, 0f), Quaternion.identity);
        currentSpawnHeight += Random.Range(minRange, maxRange);
        for (int i = 0; i < platform.Length; i++)
            platformSpawnChance += platform[i].chance;
    }

    private int RandomChance(Random_type type)
    {

        if (type == Random_type.enemy)
        {
            chance = Random.Range(0, sumOfSpawnChances);
            currentChance = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (chance >= currentChance && chance < currentChance + enemies[i].spawnChancesInDifferentLocations[System.Convert.ToInt32(Background.currentLocation.area)])
                    return i;
                currentChance += enemies[i].spawnChancesInDifferentLocations[System.Convert.ToInt32(Background.currentLocation.area)];
            }
            return -1;
        }
        else if (type == Random_type.platform)
        {
            chance = Random.Range(0, platformSpawnChance);
            currentChance = 0;
            for (int i = 0; i < platform.Length; i++)
            {
                if (chance >= currentChance && chance < currentChance + platform[i].chance)
                    return i;
                currentChance += platform[i].chance;
            }
        }
        return 0;
    }

    private void SpawnPlatform()
    {
        if (maxSpawnHeight > 50f)
        {
            minRange = 2f;
            maxRange = 2.1f;
            extraPlatformChance = 40;
        }
        else if (maxSpawnHeight > 100f)
        {
            extraPlatformChance = 30;
        }
        else if (maxSpawnHeight > 200f)
        {
            minRange = 2.1f;
            maxRange = 2.3f;
            extraPlatformChance = 20;
        }
        while (currentSpawnHeight <= maxSpawnHeight)
        {
            position = new Vector3(Random.Range(mainCamera.borderX + 0.3f, -mainCamera.borderX - 0.3f), currentSpawnHeight, 0f);
            type = RandomChance(Random_type.platform);
            if(platform[type].isActiveInDifferentLocations[System.Convert.ToInt32(Background.currentLocation.area)])
                Instantiate(platform[type], position, Quaternion.identity);
            else
                Instantiate(platform[Random.Range(0, numberOfDefaultPlatforms)], position, Quaternion.identity);
            if (Random.Range(0, 100) < extraPlatformChance)
            {
                position = new Vector3(Random.Range(mainCamera.borderX + 0.3f, -mainCamera.borderX - 0.3f), position.y + Random.Range(minRange, maxRange) / 2, 0f);
                Instantiate(platform[0], position, Quaternion.identity);
            }
            currentSpawnHeight += Random.Range(minRange, maxRange);
        }
        maxSpawnHeight = Mathf.Max(maxSpawnHeight, Player.instance.transform.position.y + 10f);
    }

    private void SpawnEnemies()
    {
        if (maxSpawnHeight > 50f)
        {
            minMobRange = 6f;
            maxMobRange = 8.5f;
        }
        else if (maxSpawnHeight > 100f)
        {
            minMobRange = 6f;
            maxMobRange = 8f;
        }
        else if (maxSpawnHeight > 200f)
        {
            minMobRange = 5f;
            maxMobRange = 8f;
        }
        while (currentMobSpawnHeight <= maxMobSpawnHeight)
        {
            position = new Vector3(Random.Range(mainCamera.borderX + 0.3f, -mainCamera.borderX - 0.3f), currentMobSpawnHeight, 0f);
            type = RandomChance(Random_type.enemy);
            if(type != -1)
                Instantiate(enemies[type], position, Quaternion.identity);
            currentMobSpawnHeight += Random.Range(minMobRange, maxMobRange);
        }
        maxMobSpawnHeight = Mathf.Max(maxMobSpawnHeight, Player.instance.transform.position.y + 15f);
    }

    void Update()
    {
        SpawnPlatform();
        SpawnEnemies();
    }
}
