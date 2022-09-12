using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBread : Enemy
{
    private turn direction = turn.stay;
    private float speed = 1f;
    private int hits = 0;
    IEnumerator Death()
    {
        ClaimGetter.getClaim(Random.Range(9, 16));
        Destroy(gameObject.GetComponent<Collider2D>());
        GetComponent<Animator>().SetBool("Dead", true);
        yield return new WaitForSeconds(0.5f);
        speed = 6f;
        direction = turn.fall;

    }

    IEnumerator Hurt()
    {
        hits++;
        GetComponent<Animator>().SetInteger("Hit", hits);
        yield break;
    }

    protected override void Behavior()
    {
        switch (direction)
        {
            case turn.fall:
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    void Start()
    {
        health = 3;
        transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        Behavior();
    }
}
