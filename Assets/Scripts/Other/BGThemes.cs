﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGThemes : MonoBehaviour
{
    public Sprite[] sprites;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
