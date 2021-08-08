using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Transform cameraa;
    void Start()
    {
        cameraa = Camera.main.transform;
    }

    void Update()
    {
        transform.position =  cameraa.position;// + new Vector3(-0.63f, -0.153f, 0.27f);
        Vector3 targetRotationVec = cameraa.rotation.eulerAngles;
        Vector3 targetEuler = targetRotationVec + new Vector3(90, 0 ,0);
        transform.rotation =    Quaternion.Euler(targetEuler);
    }
}
