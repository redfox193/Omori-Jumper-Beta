using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundAndSkyBG : MonoBehaviour
{   
    public Image image;
    [SerializeField] private float startPos = Background.Locations[System.Convert.ToInt32(Background.areas.space)].beginHeight - 25f;
    [SerializeField] private float endPos = Background.Locations[System.Convert.ToInt32(Background.areas.space)].beginHeight - 5f;
    private float progress;
    private Vector2 startColor = new Vector2(37, 211);
    private Vector2 endColor = new Vector2(108, 15);
    

    private void BackgroundChangeBeforeSpace()
    {
        if (Camera.main.transform.position.y >= startPos && Camera.main.transform.position.y <= endPos)
        {
            progress = Mathf.Abs((Camera.main.transform.position.y - startPos) / (endPos - startPos));
            image.color = new Color(image.color.r, image.color.g, image.color.b, progress);
        }
    }

    private void Start()
    {
        image.color = new Color(108f / 255f, 15f / 255f, 1f, 0f);
    }

    private void Update()
    {
        BackgroundChangeBeforeSpace();
    }
}
