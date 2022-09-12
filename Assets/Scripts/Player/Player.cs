using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead;
    public static Player instance;
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider2D;
    public PlayerJumper playerJumper;
    public Player_nature playerNature;
    public SpriteRenderer spriteRenderer;
    public Death death;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerJumper = GetComponent<PlayerJumper>();
        playerNature = GetComponent<Player_nature>();
        death = GetComponent<Death>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDead = false;
        instance = this;
    }
}