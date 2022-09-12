using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBG : MonoBehaviour
{
    public GameObject sky;
    public GameObject whiteSpace;

    private float spawnRange;
    private float maxY;
    private SkyBGMoving[] skies;
    private bool flag = true;

    private void SunnyBG()
    {
        if (flag)
        {
            Instantiate(sky, new Vector3(0f, 0f, 0f), Quaternion.identity);
            flag = false;
        }
        skies = GameObject.FindObjectsOfType<SkyBGMoving>();
        maxY = skies[0].transform.position.y;
        for (int i = 1; i < skies.Length; i++)
            maxY = Mathf.Max(maxY, skies[i].transform.position.y);
        if (maxY <= 0)
            Instantiate(sky, new Vector3(26f, 26f, 0f), Quaternion.identity);
    }

    private void OmoriBG()
    {
        if (flag)
        {
            Instantiate(whiteSpace, new Vector3(0f, 0f, 0f), Quaternion.identity);
            flag = false;
        }
    }

    private void Update()
    {
        if (ThemeManager.chosenTheme == 0)
            SunnyBG();
        else if (ThemeManager.chosenTheme == 1)
            OmoriBG();
    }
}
