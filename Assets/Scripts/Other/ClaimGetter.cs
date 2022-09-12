using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaimGetter : MonoBehaviour
{

    private static GameObject claimUI;
    private static Text claims;
    public static void getClaim(int number)
    {
        Data.SetCashInData(number);
        claimUI.SetActive(false);
        claims.text = "+" + number.ToString();
        claimUI.SetActive(true);
    }

    private void Start()
    {
        claimUI = transform.Find("Claim").gameObject;
        claims = claimUI.transform.GetComponentInChildren<Text>();
    }
}
