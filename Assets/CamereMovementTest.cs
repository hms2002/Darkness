using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereMovementTest : MonoBehaviour
{
    private Camera mainCam;
    private float rotationSpeed = 45f;
    public float id;
    public float clamm;
    //yh 
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine("rotate");
    }

    IEnumerator rotate()
    {
        for(int i = 0; i < 5; i++)
        {
            id = transform.localEulerAngles.z + 6;
            clamm = Mathf.LerpAngle(transform.localEulerAngles.z, id, Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        while(true)
        {
            for(int i = 0; i < 5; i++)
            {
                id = transform.localEulerAngles.z + 2;
                clamm = Mathf.LerpAngle(transform.localEulerAngles.z, id, Time.time);
                yield return new WaitForSeconds(0.01f);
            }
            for(int i = 0; i < 5; i++)
            {
                id = transform.localEulerAngles.z - 2;
                clamm = Mathf.LerpAngle(transform.localEulerAngles.z, id, Time.time);
                yield return new WaitForSeconds(0.01f);
            }
        }

    }
}
