using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TriggerX : MonoBehaviour
{
    public GameObject TriggerFour;
    private TextManager textManager;
    public Action CanGetWepone;
    private void Start() {
        textManager = FindObjectOfType<TextManager>();
        StartCoroutine("D");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            CanGetWepone();
            //textManager.OtherTextOn(0);
            TriggerFour.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    IEnumerator D()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
