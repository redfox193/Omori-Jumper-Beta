using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public new Camera camera;
    public float borderX;
    public float borderY;
    private Vector2 bottomLeft;

    private void Awake()
    {
        bottomLeft = camera.ScreenToWorldPoint(new Vector2(0, 0));
        borderX = bottomLeft.x;
        borderY = bottomLeft.y;
    }

    private void Update()
    {
        bottomLeft = camera.ScreenToWorldPoint(new Vector2(0, 0));
        borderX = bottomLeft.x;
        borderY = bottomLeft.y;
    }
}
