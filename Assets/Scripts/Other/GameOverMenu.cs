using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public bool GameOver = false;
    public GameObject GameOverMenuUI;

    private void Start()
    {
        GameOverMenuUI.SetActive(false);
    }

    private void Update()
    {
        if(GameOver)
        {
            GameOver = false;
            GameOverMenuUI.SetActive(true);
            LocalCanvasManager.HideComponents();
        }
    }

    public void Yes()
    {
        AudioManager.instance.ClickOnYesOrNoButton();
        SceneManager.LoadScene(1);
    }

    public void No()
    {
        AudioManager.instance.ClickOnYesOrNoButton();
        SceneManager.LoadScene(0);
    }
}
