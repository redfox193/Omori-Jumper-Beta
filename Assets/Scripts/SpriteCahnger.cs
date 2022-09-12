using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteCahnger : MonoBehaviour, IPointerDownHandler
{
    public bool isSpriteChanger;
    public int id;
    public bool left;

    private void ChangeSprite(int id)
    {
        AudioManager.instance.PlayerChangingWithSwipe();
        Player.instance.playerNature.StopAllCoroutines();
        Player.instance.playerNature.startCourutine = true;
        Player.instance.playerNature.canChange = true;
        Player.instance.playerNature.currentHero = id;
    }

    private void Abilities(bool left)
    {

        if(Player.instance.playerNature.startCourutine && !Player.instance.isDead)
            switch(Player.instance.playerNature.currentHero)
            {
                case 0:
                    Player.instance.playerNature.StartCoroutine("SunnyKnife");
                    break;
                case 1:
                    Player.instance.playerNature.StartCoroutine("Aubrey_bit", left);
                    break;
                case 2:
                    Player.instance.playerNature.StartCoroutine("Kel_stone");
                    break;
                default:
                    break;
            }    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSpriteChanger)
            ChangeSprite(id);
        else
            Abilities(left);
    }
}
