using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_nature : Player
{
    public AudioSource webCutting;
    public AudioSource bitSwing;

    public NatureThemes[] Themes;
    public GameObject kelStone;

    private Sprite[] usingHero;

    public enum _available_players {hero, sunny, kel, aubrey};
    private _available_players usingPlayer;
    private _available_players newPlayer = _available_players.sunny;
    private enum swipes { right, left };

    private GameObject aubreyRightBit;
    private GameObject aubreyLeftBit;
    private GameObject sunnyKnife;

    public bool canChange = true;
    public bool startCourutine;

    private bool isPlaying = false;
    public int currentHero = 0;
    private int previousHero;
    

    private void Start()
    {
        aubreyRightBit = transform.Find("Aubrey_right_bit").gameObject;
        aubreyLeftBit = transform.Find("Aubrey_left_bit").gameObject;
        sunnyKnife = transform.Find("Sunny_knife").gameObject;

        usingPlayer = newPlayer;
        previousHero = currentHero;
        canChange = true;
        usingHero = Themes[ThemeManager.chosenTheme].Sunny;

        BasicAbilities();
    }

    private void NatureChanger()
    {
        if (previousHero != currentHero)
        {
            previousHero = currentHero;
            switch (currentHero)
            {
                case 0:
                    usingHero = Themes[ThemeManager.chosenTheme].Sunny;
                    newPlayer = _available_players.sunny;
                    break;
                case 1:
                    usingHero = Themes[ThemeManager.chosenTheme].Aubrey;
                    newPlayer = _available_players.aubrey;
                    break;
                case 2:
                    usingHero = Themes[ThemeManager.chosenTheme].Kel;
                    newPlayer = _available_players.kel;
                    break;
                case 3:
                    usingHero = Themes[ThemeManager.chosenTheme].Hero;
                    newPlayer = _available_players.hero;
                    break;
                default:
                    break;
            }
            if(isPlaying)
            {
                if (Player.instance.rigidbody2D.velocity.x > 0f)
                {
                    spriteRenderer.sprite = usingHero[1];
                    spriteRenderer.flipX = false;
                }
                else if (Player.instance.rigidbody2D.velocity.x < 0f)
                {
                    if (usingPlayer == _available_players.aubrey)
                    {
                        spriteRenderer.sprite = usingHero[(usingHero.Length - 1) / 2 + 1];
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.sprite = usingHero[1];
                        spriteRenderer.flipX = true;
                    }
                }
            }

        }
    }

    private void AfterCourutineChange()
    {
        if(!isPlaying && Mathf.Abs(Player.instance.rigidbody2D.velocity.x) < 0.5f)
        {
            spriteRenderer.sprite = usingHero[0];
            spriteRenderer.flipX = false;
        }
        else if (Player.instance.rigidbody2D.velocity.x >= 0f)
        {
            spriteRenderer.sprite = usingHero[1];
            spriteRenderer.flipX = false;
        }
        else if (Player.instance.rigidbody2D.velocity.x < 0f)
        {
            if (usingPlayer == _available_players.aubrey)
            {
                spriteRenderer.sprite = usingHero[(usingHero.Length - 1) / 2 + 1];
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.sprite = usingHero[1];
                spriteRenderer.flipX = true;
            }
        }
        canChange = true;
    }
    private void SpriteMovingChanger()
    {
        if (canChange)
        {
            if (Player.instance.rigidbody2D.velocity.x > 0.5f)
            {
                isPlaying = true;
                spriteRenderer.sprite = usingHero[1];
                spriteRenderer.flipX = false;
            }
            else if (Player.instance.rigidbody2D.velocity.x < -0.5f)
            {
                isPlaying = true;
                if (usingPlayer == _available_players.aubrey)
                {
                    spriteRenderer.sprite = usingHero[(usingHero.Length - 1) / 2 + 1];
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.sprite = usingHero[1];
                    spriteRenderer.flipX = true;
                }
            }
            else if(!isPlaying)
            {
                spriteRenderer.sprite = usingHero[0];
                spriteRenderer.flipX = false;
            }
        }
    }

    private void BasicAbilities()
    {
        Player.instance.playerJumper.jumpforce = 7f;
        aubreyLeftBit.SetActive(false);
        aubreyRightBit.SetActive(false);
        sunnyKnife.SetActive(false);
        startCourutine = true;
    }

    private void Hero()
    {
        Player.instance.playerJumper.jumpforce = 8.2f;
    }

    IEnumerator SunnyKnife()
    {
        if (VolumeButton.isVolumeON)
            webCutting.Play();
        startCourutine = false;
        canChange = false;
        spriteRenderer.flipX = false;
        spriteRenderer.sprite = usingHero[2];
        for(int i = 2; i < usingHero.Length; i++)
        {
            if(i == 4)
                sunnyKnife.SetActive(true);
            else if(i == usingHero.Length - 1)
                sunnyKnife.SetActive(false);
            spriteRenderer.sprite = usingHero[i];
            yield return new WaitForSeconds(.12f);
        }
        AfterCourutineChange();
        yield return new WaitForSeconds(.2f);
        startCourutine = true;
        yield break;
    }

    IEnumerator Aubrey_bit(bool left)
    {
        if (VolumeButton.isVolumeON)
            bitSwing.Play();
        startCourutine = false;
        canChange = false;
        spriteRenderer.flipX = false;
        if (left)
        {
            for (int i = (usingHero.Length - 1) / 2 + 2; i < usingHero.Length; i++)
            {
                spriteRenderer.sprite = usingHero[i];
                if(i == usingHero.Length - 1)
                    aubreyLeftBit.SetActive(true);
                yield return new WaitForSeconds(.09f);
            }
        }
        else
        {
            for (int i = 2; i < (usingHero.Length - 1) / 2 + 1; i++)
            {
                spriteRenderer.sprite = usingHero[i];
                if (i == (usingHero.Length - 1) / 2)
                    aubreyRightBit.SetActive(true);
                yield return new WaitForSeconds(.09f);
            }
        }
        yield return new WaitForSeconds(.1f);
        AfterCourutineChange();
        aubreyLeftBit.SetActive(false);
        aubreyRightBit.SetActive(false);
        yield return new WaitForSeconds(.5f);
        startCourutine = true;
        yield break;
    }

    IEnumerator Kel_stone()
    {
        startCourutine = false;
        canChange = false;
        spriteRenderer.flipX = false;
        spriteRenderer.sprite = usingHero[2];
        yield return new WaitForSeconds(.2f);
        spriteRenderer.sprite = usingHero[3];
        Vector3 _position;
        _position = new Vector3(transform.position.x, transform.position.y + 0.7f, -4f);
        Instantiate(kelStone, _position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        AfterCourutineChange();
        yield return new WaitForSeconds(.5f);
        startCourutine = true;
        yield break;
    }

    private void Playerabilities()
    {
        if (newPlayer != usingPlayer)
        {
            BasicAbilities();
            usingPlayer = newPlayer;
            if (usingPlayer == _available_players.hero)
                Hero();
        }
    }    

    private void FixedUpdate()
    {
        if (!Player.instance.isDead)
        {
            NatureChanger();
            SpriteMovingChanger();
            Playerabilities();
        }
        else
            spriteRenderer.sprite = usingHero[0];
    }
}
