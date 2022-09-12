using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[RequireComponent(typeof(Rigidbody2D))]*/
public class PlayerJumper : Player
{
    public AudioSource jump;
    public float jumpforce = 7f;
    private float speed = 10f;
    private CameraSize mainCamera;
    public static bool isHead = false;

    private void Start()
    {
        mainCamera = GameObject.FindObjectOfType<CameraSize>();
        StartCoroutine("Move");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Platform platform) && !isDead)
        {
            if(VolumeButton.isVolumeON)
                jump.Play();
            Player.instance.rigidbody2D.velocity = new Vector2(Player.instance.rigidbody2D.velocity.x, 0f);
            Player.instance.rigidbody2D.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (Player.instance.rigidbody2D.velocity.x * Input.acceleration.x < 0f)
                Player.instance.rigidbody2D.velocity = new Vector2(Input.acceleration.x * speed * 2f, Player.instance.rigidbody2D.velocity.y);
            else
                Player.instance.rigidbody2D.velocity = new Vector2(Input.acceleration.x * speed, Player.instance.rigidbody2D.velocity.y);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Move1()
    {

        if (Input.GetKey(KeyCode.A))
            Player.instance.rigidbody2D.AddForce(Vector2.left * 30f);
        else if (Input.GetKey(KeyCode.D))
            Player.instance.rigidbody2D.AddForce(Vector2.right * 30f);
    }
    private void Position_controler()
    {
        if (Mathf.Abs(transform.position.x) > -mainCamera.borderX)
            if(transform.position.x > 0)
                transform.position = new Vector3(mainCamera.borderX + 0.1f, transform.position.y, -5f);
            else
                transform.position = new Vector3(-mainCamera.borderX - 0.1f, transform.position.y, -5f);
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            Position_controler();
            if (Mathf.Abs(Player.instance.rigidbody2D.velocity.x) > 5f)
                if (Player.instance.rigidbody2D.velocity.x < 0f)
                    Player.instance.rigidbody2D.velocity = new Vector2(-4.99f, Player.instance.rigidbody2D.velocity.y);
                else
                    Player.instance.rigidbody2D.velocity = new Vector2(4.99f, Player.instance.rigidbody2D.velocity.y);
            else
                Move1();
            if (Player.instance.rigidbody2D.velocity.y < -7.5f)
                Player.instance.rigidbody2D.velocity = new Vector2(Player.instance.rigidbody2D.velocity.x, -7.5f);
            else if (Player.instance.rigidbody2D.velocity.y > 10f)
                Player.instance.rigidbody2D.velocity = new Vector2(Player.instance.rigidbody2D.velocity.x, 10f);
        }
        else
            StopCoroutine("Move");
    }
}
