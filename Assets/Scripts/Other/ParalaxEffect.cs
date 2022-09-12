using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    private Camera mainCamera;
    private float previosPos;
    [SerializeField] private float deltaY;
    public float speed;

    private void Start()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>();
        previosPos = mainCamera.transform.position.y;
        StartCoroutine("PreviousY");
    }

    IEnumerator PreviousY()
    {
        while(true)
        {
            previosPos = mainCamera.transform.position.y;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        deltaY = mainCamera.transform.position.y - previosPos;
        transform.position = new Vector3(transform.position.x, transform.position.y - deltaY * speed, transform.position.z);
    }
}
