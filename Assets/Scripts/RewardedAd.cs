using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAd : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = false;
    [SerializeField] private Button adsButton;

    private string gameID = "4272530";

    private string rewardedVideo = "Rewarded_Android";

    void Start()
    {

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);

        adsButton = GetComponent<Button>();
        adsButton.interactable = true;
        //adsButton.interactable = Advertisement.IsReady(rewardedVideo);

        if (adsButton)
            adsButton.onClick.AddListener(ShowRewardedVideo);
    }

    private void ShowRewardedVideo()
    {
        AudioManager.instance.ClickOnButton();
        Advertisement.Show(rewardedVideo);
    }


    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Data.SetCashInData(100);
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Skipped");
        }
        else if(showResult == ShowResult.Failed)
        {
            Debug.Log("Failed");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {
        adsButton.interactable = true;
        //if (placementId == rewardedVideo)
        //{
        //    adsButton.interactable = true;
        //}
    }
}
