using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBGMoving : MonoBehaviour
{
    private float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector2(-1f, -1f) * speed * Time.deltaTime);
    }
}
