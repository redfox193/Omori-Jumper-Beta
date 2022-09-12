using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOright : Enemy
{
    private CameraSize mainCamera;
    private Animator animator;
    private turn direction;
    private SpriteRenderer UFOSprite;
    private float speed;

    public bool UFOleftDead;
    public UFOleft ufoLeft;

    IEnumerator Death()
    {
        ufoLeft.UFOrightDead = true;
        Destroy(gameObject.GetComponent<Collider2D>());
        direction = turn.stay;
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(0.5f);
        speed = 6f;
        direction = turn.fall;
    }

    protected override void Behavior()
    {
        switch (direction)
        {
            case turn.right:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;
            case turn.left:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            case turn.fall:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        if (transform.position.x >= -mainCamera.borderX - 0.25f)
        {
            direction = turn.left;
            UFOSprite.flipX = true;
        }
        else if (UFOleftDead && transform.position.x <= mainCamera.borderX + 0.25f)
        {
            direction = turn.right;
            UFOSprite.flipX = false;
        }
        else if (!UFOleftDead && transform.position.x <= mainCamera.borderX + 0.75f)
        {
            direction = turn.right;
            UFOSprite.flipX = false;
        }
    }

    private void Start()
    {
        health = 1;
        UFOleftDead = false;
        mainCamera = GameObject.FindObjectOfType<CameraSize>();
        UFOSprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        direction = turn.right;
        speed = 0.9f;
        animator.SetTrigger("Idle2");
    }

    private void Update()
    {
        Behavior();
    }
}

