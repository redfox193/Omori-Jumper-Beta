using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : Platform
{
    private CameraSize cameraSize;
    private float speed = 0.8f;
    private enum turn { right, left };
    private turn direction;

    void Start()
    {
        SpriteChanger();
        cameraSize = GameObject.FindObjectOfType<CameraSize>();
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        direction = turn.left;
    }

    private void Moving()
    {
        switch (direction)
        {
            case turn.right:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;
            case turn.left:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        if (transform.position.x >= -cameraSize.borderX - 0.4f)
            direction = turn.left;
        else if (transform.position.x <= cameraSize.borderX + 0.4f)
            direction = turn.right;
    }

    void Update()
    {
        Moving();
    }
}
