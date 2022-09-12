using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destoyRange;

    private void Update()
    {
        if (Player.instance.transform.position.y - transform.position.y > destoyRange)
            Destroy(gameObject);
    }
}
