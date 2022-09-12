using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web_interaction : MonoBehaviour
{
    public Sprite[] spritesCut;
    public Sprite[] spritesRebound;
    public Sprite[] spritesSlip;
    public PlatformWithWeb parentPlatform;
    public Web_barier webBarier;

    private SpriteRenderer spriteRenderer;
    private bool isCutting = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator WebCut()
    {
        Destroy(webBarier.gameObject);
        parentPlatform.gameObject.GetComponent<Platform_for_jumping>().StartCoroutine("BugFix");
        for (int i = 0; i < spritesCut.Length; i++)
        {
            spriteRenderer.sprite = spritesCut[i];
            yield return new WaitForSeconds(.15f);
        }
        Destroy(gameObject);
    }

    IEnumerator WebRebound()
    {
        for (int i = 0; i < spritesRebound.Length; i++)
        {
            spriteRenderer.sprite = spritesRebound[i];
            yield return new WaitForSeconds(.05f);
        }
        yield break;
    }

    IEnumerator WebSlip()
    {
        for (int i = 0; i < spritesSlip.Length; i++)
        {
            spriteRenderer.sprite = spritesSlip[i];
            yield return new WaitForSeconds(.05f);
        }
        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Knife" && !isCutting)
        {
            isCutting = true;
            StopAllCoroutines();
            StartCoroutine("WebCut");
        }
    }
}
