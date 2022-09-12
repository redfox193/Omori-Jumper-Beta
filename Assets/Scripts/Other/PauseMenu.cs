using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool gameIsPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(gameIsPaused)
                Resume();
            else
                Pause();
    }

    public void Resume()
    {
        AudioManager.instance.ClickOnResumeOrPlayButton();
        pauseMenuUI.SetActive(false);
        LocalCanvasManager.ShowComponents();
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void MainMenu()
    {
        AudioManager.instance.ClickOnButton();
        Data.SetRecordInData((int)(Game_over.max_height + 5f));
        gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        AudioManager.instance.ClickOnButton();
        pauseMenuUI.SetActive(true);
        LocalCanvasManager.HideComponents();
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Quit()
    {
        AudioManager.instance.ClickOnButton();
        Data.SetRecordInData((int)(Game_over.max_height + 5f));
        Application.Quit();
    }
}
