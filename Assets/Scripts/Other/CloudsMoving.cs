using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoving : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > 10f)
            Destroy(gameObject);
    }
}
