using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public bool isActive { get; private set; }

    private void Activate()
    {
        isActive = true;
    }

    private void DisActivate()
    {
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive && Player.instance.rigidbody2D.velocity.y < 0f)
            Game_over.GameOver();
    }
}
