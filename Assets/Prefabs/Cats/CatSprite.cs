using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSprite : MonoBehaviour
{
    private Quaternion RotationZ;

    private void Start()
    {
        RotationZ = Quaternion.AngleAxis(1, Vector3.forward);
        if (ThemeManager.chosenTheme == 0)
            GetComponent<Animator>().SetInteger("Cat", Random.Range(1, 9));
        else
            GetComponent<Animator>().SetInteger("Cat", 0);
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
