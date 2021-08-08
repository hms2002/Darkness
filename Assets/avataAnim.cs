using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avataAnim : MonoBehaviour
{
    private Animator anim;
    public Transform target;
    private Transform mainCam;

    private void OnEnable() {
        
        mainCam = Camera.main.transform;
        anim = GetComponent<Animator>();
    }


    private void OnAnimatorIK(int layerIndex) {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        Vector3 originalRotationInVector3 = mainCam.rotation.eulerAngles;
        Vector3 targetRotitionVec = originalRotationInVector3 + new Vector3(120,90, 180);

        Quaternion targetTransform = Quaternion.Euler(targetRotitionVec);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand,targetTransform);
    }

}
