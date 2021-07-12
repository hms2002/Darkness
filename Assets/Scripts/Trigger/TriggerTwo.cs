using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class TriggerTwo : MonoBehaviour
{
    public event Action trigger2;
    private void Start() {
        StartCoroutine("StartFalse");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            trigger2();
            gameObject.SetActive(false);
        }
    }
    IEnumerator StartFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}