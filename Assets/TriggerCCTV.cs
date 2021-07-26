using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCCTV : MonoBehaviour
{
    public GameObject CCTVQuad;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            CCTVQuad.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
