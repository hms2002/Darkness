using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThreePlus : MonoBehaviour
{
    private TVLightBlink tVLightBlink;
    private void Start() {
        tVLightBlink = FindObjectOfType<TVLightBlink>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            tVLightBlink.StopLight();
        }
    }
}
