using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightPotition : MonoBehaviour
{
    public Transform targret;
    void Update()
    {
        Vector3 targetRotation = targret.position - transform.position;
//        Vector3 originalRotationInVector3 = targret.rotation.eulerAngles;
        Vector3 targetRotitionVec = targetRotation + new Vector3(40,-70, 25);

        //Quaternion targetTransform = Quaternion.Euler(targetRotitionVec);

        transform.rotation = Quaternion.Euler(targetRotitionVec);
        
    }
}
