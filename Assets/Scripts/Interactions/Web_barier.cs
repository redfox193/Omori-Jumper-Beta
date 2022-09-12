using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web_barier : MonoBehaviour
{
    public Web_interaction webInteraction;
    private BoxCollider2D boxCollider2D;
    private float rangeY;
    private const float error = 0.3f;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rangeY = Player.instance.boxCollider2D.size.y * transform.lossyScale.y / 2 + boxCollider2D.size.y * transform.lossyScale.y / 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.rigidbody2D.AddForce(Vector3.up * -1.5f, ForceMode2D.Impulse);
            webInteraction.StartCoroutine("WebRebound");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            webInteraction.StartCoroutine("WebSlip");
    }

    private void Update()
    {
        if (Player.instance.rigidbody2D.velocity.y < 2f)
            boxCollider2D.isTrigger = true;
        else if (Player.instance.transform.position.y + rangeY - error > transform.position.y)
            boxCollider2D.isTrigger = true;
        else
            boxCollider2D.isTrigger = false;
    }
}
