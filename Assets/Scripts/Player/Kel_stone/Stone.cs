using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 10f;
    public AudioSource stoneThrow;

    void Start()
    {
        if (VolumeButton.isVolumeON)
            stoneThrow.Play();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed);
    }

    private void Update()
    {
        if (Mathf.Abs(Player.instance.transform.position.y - transform.position.y) > 10f)
            Destroy(gameObject);
    }
}
