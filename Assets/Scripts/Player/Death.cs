using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Player
{
    public Rigidbody2D playerRigidbody2D;

    private Vector3 startPosition;
    private Quaternion RotationZ;
    private bool isCalled;

    private void Start()
    {
        isCalled = false;
        RotationZ = Quaternion.AngleAxis(4, Vector3.forward);
    }

    private float FuncY(float p)
    {
        return (-6.25f * (p - 0.4f) * (p - 0.4f) + 1f);
    }

    IEnumerator DeathRotating()
    {
        for (float i = 0; i < 45; i += 1f)
        {
            transform.rotation *= RotationZ;
            yield return new WaitForSeconds(0.001f);
        }
        yield break;
    }
    IEnumerator DeathFalling()
    {
        for (float i = 0; i < 1.7; i += 0.01f)
        {
            transform.position = new Vector3(startPosition.x, startPosition.y + FuncY(i), startPosition.z);
            yield return new WaitForSeconds(0.005f);
        }
        GameOverMenu gameOverMenu = GameObject.FindObjectOfType<GameOverMenu>();
        gameOverMenu.GameOver = true;
        yield break;
    }

    private void Update()
    {
        if (Player.instance.isDead && !isCalled)
        {
            startPosition = transform.position;
            isCalled = true;
            playerRigidbody2D.bodyType = RigidbodyType2D.Static;
            StartCoroutine("DeathFalling");
            StartCoroutine("DeathRotating");
        }   
    }
}
