using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_for_jumping : MonoBehaviour
{
    private float platformColliderPositionY;
    private float playerColliderPositionY;
    private BoxCollider2D platformCollider;


    private float velocityY;

    //уникальные элементы
    public bool ghostHide = false;
    private bool f = false;
    private Platform.platformTypes type;

    IEnumerator BugFix()
    {
        f = true;
        int i = 0;
        while(i < 5)
        {
            velocityY = Player.instance.rigidbody2D.velocity.y;
            if (Player.instance.transform.position.y - gameObject.transform.position.y < 0.65f &&
                Player.instance.transform.position.y - gameObject.transform.position.y > 0.45f &&
                Mathf.Abs(Player.instance.transform.position.x - gameObject.transform.position.x) < 0.5f)
            {
                Player.instance.rigidbody2D.velocity = new Vector2(Player.instance.rigidbody2D.velocity.x, 0);
                Player.instance.rigidbody2D.AddForce(Vector3.up * Player.instance.playerJumper.jumpforce, ForceMode2D.Impulse);
                GetComponent<PlatformWithWeb>().hidePlatform = false;
                yield break;
            }
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<PlatformWithWeb>().hidePlatform = false;
        f = false;
    }

    private void BugFixingJump()//Помогает спрайту прыгнуть, если он застревает в платформе
    {
        if(!Player.instance.isDead && !f)
        {
            velocityY = Player.instance.rigidbody2D.velocity.y;
            if (Player.instance.transform.position.y - gameObject.transform.position.y < 0.7f &&
                Player.instance.transform.position.y - gameObject.transform.position.y > 0.5f &&
                Mathf.Abs(Player.instance.transform.position.x - gameObject.transform.position.x) < 0.5f
                && Mathf.Abs(velocityY) < 0.01f) 
            {
                Player.instance.rigidbody2D.velocity = new Vector2(Player.instance.rigidbody2D.velocity.x, 0);
                Player.instance.rigidbody2D.AddForce(Vector3.up * Player.instance.playerJumper.jumpforce, ForceMode2D.Impulse);
            }
        }
    }

    private void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>();
        if (TryGetComponent<PlatformWithWeb>(out PlatformWithWeb script1))
            type = Platform.platformTypes.webPlatform;
        else if (TryGetComponent<Ghost_platform>(out Ghost_platform script2))
            type = Platform.platformTypes.ghostPlatform;
        else
            type = Platform.platformTypes.standart;
    }

    private void Activator()
    {
        velocityY = Player.instance.rigidbody2D.velocity.y;
        platformColliderPositionY = transform.position.y + platformCollider.size.y * transform.localScale.y / 2;
        playerColliderPositionY = Player.instance.transform.position.y - Player.instance.boxCollider2D.size.y * Player.instance.transform.localScale.y / 2;
        if (velocityY < 0f)
            if (playerColliderPositionY > platformColliderPositionY - 0.16f)
                platformCollider.isTrigger = false;
            else
                platformCollider.isTrigger = true;
        else
            if (playerColliderPositionY > platformColliderPositionY)
                platformCollider.isTrigger = false;
            else
                platformCollider.isTrigger = true;
    }

    private void Update()
    {
        switch (type)
        {
            case Platform.platformTypes.standart:
                Activator();
                break;
            case Platform.platformTypes.webPlatform:
                if(!GetComponent<PlatformWithWeb>().hidePlatform)
                    Activator();
                else
                    platformCollider.isTrigger = true;
                break;
            case Platform.platformTypes.ghostPlatform:
                if(!ghostHide)
                    Activator();
                else
                    platformCollider.isTrigger = true;
                break;
            default:
                break;
        }
        BugFixingJump();
    }
}
