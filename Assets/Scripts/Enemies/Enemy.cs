using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public AudioSource hitEnemyWithStone;
    protected int health;
    public Game_over gameOver;
    public int[] spawnChancesInDifferentLocations;
    protected enum turn { right, left, stay, fall };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stone" && gameObject.tag != "Ghost")
        {
            if (VolumeButton.isVolumeON)
                hitEnemyWithStone.Play();
            Destroy(collision.gameObject);
            health -= 1;
            if (health == 0)
                StartCoroutine("Death");
            else
                StartCoroutine("Hurt");
        }
        else if (collision.tag == "Player")
        {
            if (Player.instance.rigidbody2D.velocity.y < 0f && Player.instance.transform.position.y - gameObject.transform.position.y > 0.6f && tag == "WaterMelon")
            {
                Player.instance.rigidbody2D.velocity = new Vector2(Player.instance.rigidbody2D.velocity.x, 0f);
                Player.instance.rigidbody2D.AddForce(Vector3.up * Player.instance.playerJumper.jumpforce, ForceMode2D.Impulse);
                if (VolumeButton.isVolumeON)
                    Player.instance.playerJumper.jump.Play();
                StartCoroutine("Death");
            }
            else
                Game_over.GameOver();
        }
    }

    protected abstract void Behavior();
}
