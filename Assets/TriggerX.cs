using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TriggerX : MonoBehaviour
{
    public GameObject TriggerFour;
    public Action CanGetWepone;
    private void Start() {
        StartCoroutine("D");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            CanGetWepone();
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
