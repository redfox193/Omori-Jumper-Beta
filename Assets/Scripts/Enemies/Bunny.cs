using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Enemy
{
    private CameraSize mainCamera;
    private Animator animator;
    private turn direction;
    private SpriteRenderer bunnySprite;
    private float speed;


    IEnumerator Death()
    {
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
            bunnySprite.flipX = false;
        }
        else if(transform.position.x <= mainCamera.borderX + 0.25f)
        {
            direction = turn.right;
            bunnySprite.flipX = true;
        }    
    }

    private void Start()
    {
        health = 1;
        mainCamera = GameObject.FindObjectOfType<CameraSize>();
        bunnySprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        if (Background.currentLocation.area == Background.areas.space)
            animator.SetTrigger("Space");
        direction = turn.left;
        speed = 1f;
    }

    private void Update()
    {
        Behavior();
    }
}
