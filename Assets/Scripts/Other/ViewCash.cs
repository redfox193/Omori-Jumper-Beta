using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewCash : MonoBehaviour
{
    private Text cash;

    private void Start()
    {
        cash = GetComponent<Text>();
    }

    private void Update()
    {
        cash.text = System.Convert.ToString(Data.cash);
    }
}