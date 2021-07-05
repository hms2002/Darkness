using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeTriggerThree : MonoBehaviour
{
    private Knife knife;
    void Start()
    {
        knife = FindObjectOfType<Knife>();
        knife.getKnifeEvent += AwakeChild;
    }

    public void AwakeChild()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
