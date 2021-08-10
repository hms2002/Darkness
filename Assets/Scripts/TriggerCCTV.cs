using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCCTV : MonoBehaviour
{
    public GameObject SpotLight;
    public GameObject CCTVQuad;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            SpotLight.SetActive(false);
            CCTVQuad.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
