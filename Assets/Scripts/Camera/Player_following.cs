using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_following : MonoBehaviour
{
    private float dumpingUp = 1.5f;
    private float dumpingDown = 4f;
    private float maxHeight;
    private float minHeight;
    private bool flag;

    private void Start()
    {
        flag = true;
        maxHeight = 0f;
        minHeight = Player.instance.transform.position.y;
        //StartCoroutine("CameraBugFixing", new Vector3(0f, transform.position.y - 0.2f, -10f));
    }

    IEnumerator CameraBugFixing(Vector3 endPos)
    {
        while (Mathf.Abs(transform.position.y - endPos.y) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, dumpingDown * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }

    private void CameraFolowing()
    {
        if (!Player.instance.isDead)
        {
            maxHeight = Mathf.Max(maxHeight, Player.instance.transform.position.y);
            if (transform.position.y - Player.instance.transform.position.y > 4.5f && transform.position.y > 0f)
            {
                StopAllCoroutines();
                if (flag)
                {
                    flag = false;
                    minHeight = Player.instance.transform.position.y;
                }
                minHeight = Mathf.Min(Player.instance.transform.position.y, minHeight);
                maxHeight = Player.instance.transform.position.y;
                transform.position = new Vector3(0f, minHeight + 4.5f, -10f);
            }
            else if(transform.position.y - Player.instance.transform.position.y < 4.4f && !flag)
            {
                flag = true;
                StopAllCoroutines();
                StartCoroutine("CameraBugFixing", new Vector3(0f, Mathf.Max(transform.position.y - 0.5f, 0f), -10f));
            }
            else if (transform.position.y - maxHeight < 0f)
            {
                StopAllCoroutines();
                flag = true;
                transform.position = Vector3.Lerp(transform.position, new Vector3(0f, maxHeight + 0.4f, -10f), dumpingUp * Time.deltaTime);
            }
        }
    }

    private void Update()
    {
        //maxHeight = Mathf.Max(maxHeight, Player.instance.transform.position.y);
        //transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        CameraFolowing();
    }
}
