using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        gameObject.transform.SetParent(canvas.transform);
        transform.localScale = new Vector2(0.95f, 0.95f);
    }
}
