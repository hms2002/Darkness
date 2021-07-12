using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class triggerOne : MonoBehaviour
{
    public event Action TriggerOne;
    private TextManager textManager;
    private void Start() {
        textManager = FindObjectOfType<TextManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            TriggerOne();
            StartCoroutine("StairText");
        }
    }
    IEnumerator StairText()
    {
        yield return new WaitForSeconds(0.5f);
        textManager.StairTextOn(0);
        gameObject.SetActive(false);
    }
}
