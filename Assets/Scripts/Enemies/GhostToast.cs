using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostToast : Enemy
{
    private float speed = 0.9f;
    private CameraSize camera;
    private float firstY;
    private const float parametr = 0.3f;

    IEnumerator Levitating()
    {
        float x = 0;
        while(true)
        {
            transform.position = new Vector2(transform.position.x, firstY + parametr * Mathf.Sin(x));
            x += 0.1f;
            if (x >= 6.28f)
                x = 0f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    protected override void Behavior()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > -camera.borderX)
            if (transform.position.x > 0)
                transform.position = new Vector3(camera.borderX + 0.1f, transform.position.y);
            else
                transform.position = new Vector3(-camera.borderX - 0.1f, transform.position.y);
    }

    private void Start()
    {
        health = 1;
        camera = FindObjectOfType<CameraSize>();
        firstY = transform.position.y;
        StartCoroutine("Levitating");
    }

    void Update()
    {
        Behavior();
    }
}
