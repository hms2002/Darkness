using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TriggerSpecial : MonoBehaviour
{
    public Action doorOff;
    void Start()
    {
        StartCoroutine("StartOff");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            doorOff();
            gameObject.SetActive(false);
        }
    }

    IEnumerator StartOff()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
