using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLemon : Enemy
{
    public GameObject stem;
    public GameObject head;
    private turn direction = turn.stay;
    private float speed = 1f;
    IEnumerator Death()
    {
        ClaimGetter.getClaim(Random.Range(2, 5));
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(head);
        GetComponent<Animator>().SetBool("Dead", true);
        Instantiate(stem, new Vector2(transform.position.x, transform.position.y + 0.01f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        speed = 6f;
        direction = turn.fall;

    }

    protected override void Behavior()
    {
        switch (direction)
        {
            case turn.fall:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    void Start()
    {
        health = 1;
        transform.localPosition = new Vector3(Random.Range(-0.2f, 0.2f), transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        Behavior();
    }
}
