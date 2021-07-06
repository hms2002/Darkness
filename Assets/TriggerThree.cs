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
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            tVLightBlink.LightBlink();
            gameObject.SetActive(false);
        }
    }
}
