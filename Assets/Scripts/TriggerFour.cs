using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFour : MonoBehaviour
{
    private GameObject ghost;
    private void Start() {
        ghost = GameObject.Find("Ghost");
        StartCoroutine("StartFalse");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            ghost.SetActive(true);
            ghost.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    IEnumerator StartFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    
}
