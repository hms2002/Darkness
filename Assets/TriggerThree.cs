using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThree : MonoBehaviour
{
    private TVLightBlink tVLightBlink;
    private GameObject TriggerThirdParent;
    void Start()
    {
        tVLightBlink = FindObjectOfType<TVLightBlink>();
        TriggerThirdParent = GameObject.Find("TriggerThreePlusParent");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            tVLightBlink.LightBlink();
            TriggerThirdParent.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
