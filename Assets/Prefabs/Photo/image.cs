using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image : MonoBehaviour
{
    public Sprite[] farawayPhotoes;
    public Sprite[] headSpacePhotoes;
    private Quaternion RotationZ;

    private void Start()
    {
        RotationZ = Quaternion.AngleAxis(1, Vector3.forward);
        if (ThemeManager.chosenTheme == 0)
            GetComponent<SpriteRenderer>().sprite = farawayPhotoes[Random.Range(0, farawayPhotoes.Length)];
        else
            GetComponent<SpriteRenderer>().sprite = headSpacePhotoes[Random.Range(0, headSpacePhotoes.Length)];
        StartCoroutine("Rotating");
    }
    IEnumerator Rotating()
    {
        while (true)
        {
            transform.rotation *= RotationZ;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
