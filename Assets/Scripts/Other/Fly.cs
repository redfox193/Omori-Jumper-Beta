using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public GameObject Object;
    private CameraSize cameraSize;
    private float speed;
    public bool right;
    private float range = 0.8f;
    public static int flag;

    private void Start()
    {
        speed = Random.Range(0.8f, 1f);
        cameraSize = GameObject.FindObjectOfType<CameraSize>();
        if(flag < 3)
        {
            flag++;
            transform.position = new Vector2(Random.Range(cameraSize.borderX - range, -(cameraSize.borderX - range)), transform.position.y);
        }
        else if(right)
            transform.position = new Vector2(cameraSize.borderX - range, transform.position.y);
        else
            transform.position = new Vector2(-(cameraSize.borderX - range), transform.position.y);
    }
    private void Update()
    {
        if (right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > -(cameraSize.borderX - range))
            {
                Instantiate(Object, new Vector2(cameraSize.borderX - range, transform.position.y), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < cameraSize.borderX - range)
            {
                Instantiate(Object, new Vector2(-(cameraSize.borderX - range), transform.position.y), Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }
}
