using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpMenu : MonoBehaviour
{
    public GameObject[] helpPages;
    public GameObject rightHand;
    public GameObject leftHand;
    private int currentPage = 0;
    private Image rightColor;
    private Image leftColor;

    private void Awake()
    {
        Fly.flag = 0;
        leftColor = leftHand.GetComponent<Image>();
        rightColor = rightHand.GetComponent<Image>();
        ChangePage(0);
    }

    public void ChangePage(int id)
    {
        for (int i = 0; i < helpPages.Length; i++)
            helpPages[i].SetActive(false);
        helpPages[currentPage].SetActive(true);
        if(id == 0)
            leftColor.color = new Color(leftColor.color.r, leftColor.color.g, leftColor.color.b, 0f);
        else if(id == helpPages.Length - 1)
            rightColor.color = new Color(rightColor.color.r, rightColor.color.g, rightColor.color.b, 0f);
        else
        {
            leftColor.color = new Color(leftColor.color.r, leftColor.color.g, leftColor.color.b, 1f);
            rightColor.color = new Color(rightColor.color.r, rightColor.color.g, rightColor.color.b, 1f);
        }
    }

    public void BackToMenu()
    {
        AudioManager.instance.ClickOnButton();
        SceneManager.LoadScene(0);
    }

    public void OpenHandBook()
    {
        AudioManager.instance.ClickOnButton();
        SceneManager.LoadScene(4);
    }

    public void BackToHelp()
    {
        AudioManager.instance.ClickOnButton();
        SceneManager.LoadScene(3);
    }

    public void RightHand()
    {
        if(rightColor.color.a != 0f)
            AudioManager.instance.ClickOnButton();
        if (currentPage != helpPages.Length - 1)
        {
            currentPage++;
            ChangePage(currentPage);
        }
    }
    public void LeftHand()
    {
        if (leftColor.color.a != 0f)
            AudioManager.instance.ClickOnButton();
        if (currentPage != 0)
        {
            currentPage--;
            ChangePage(currentPage);
        }
    }
}
