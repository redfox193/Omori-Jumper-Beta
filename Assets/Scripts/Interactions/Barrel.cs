using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public AudioSource barrelBroken;
    public AudioSource peaceBroken;

    public Sprite[] sprites;

    private int usingSprite;
    private SpriteRenderer spriteRenderer;
    private bool flag = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bit" && !flag)
        {
            flag = true;
            spriteRenderer.sprite = sprites[usingSprite + sprites.Length / 2];
            if (usingSprite == 0)
            {
                ClaimGetter.getClaim(Random.Range(4, 6));
                if (VolumeButton.isVolumeON)
                    barrelBroken.Play();
            }
            else
            {
                ClaimGetter.getClaim(Random.Range(5, 9));
                if (VolumeButton.isVolumeON)
                    peaceBroken.Play();
            }
            StartCoroutine("Destroyer");
        }
    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(1f);
        for (float ft = 1f; ft >= 0; ft -= 0.05f)
        {
            Color c = spriteRenderer.color;
            c.a = ft;
            spriteRenderer.color = c;
            yield return new WaitForSeconds(.05f);
        }
        Destroy(gameObject);
        yield break;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        usingSprite = Random.Range(0, sprites.Length / 2);
        spriteRenderer.sprite = sprites[usingSprite];
        transform.localPosition = new Vector3(Random.Range(-0.2f, 0.2f), transform.localPosition.y, transform.localPosition.z);
    }
}
