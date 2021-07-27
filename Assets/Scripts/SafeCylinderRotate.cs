using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCylinderRotate : MonoBehaviour
{

    public float rotate = 90f; 
    private SafeUIManager safeUIManager;
    private SafeDoorLittleOpen safeDoorLittle;
    void Start()
    {
        safeUIManager = FindObjectOfType<SafeUIManager>();
        safeUIManager.SafeOpenAction += Rotate;
        safeDoorLittle = FindObjectOfType<SafeDoorLittleOpen>();
    }

    public void Rotate()
    {
        StartCoroutine("IRotate");
    }

    IEnumerator IRotate()
    {
        for(int i = 0; i < 50; i++)
        {
            transform.Rotate(rotate/50, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        safeDoorLittle.Rotation();
    }
}
