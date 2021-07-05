using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnePlus : MonoBehaviour
{
    private TextManager textManager;
    void Start()
    {
        textManager = FindObjectOfType<TextManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            textManager.StairTextOn(1);
        }
    }
}
