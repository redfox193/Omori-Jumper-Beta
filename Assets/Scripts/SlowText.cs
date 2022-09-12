using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowText : MonoBehaviour
{
    private Text text;
    public string s;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
        StartCoroutine("SlowWriting");
    }

    IEnumerator SlowWriting()
    {
        for (int i = 0; i < s.Length; i++)
        {
            Debug.Log(s[i]);
            text.text += s[i];
            yield return new WaitForSeconds(0.08f);
        }
        yield break;
    }
}
