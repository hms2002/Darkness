using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFourPlus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            transform.parent.gameObject.GetComponent<Ghost>().alreadyDest = true;
            transform.parent.gameObject.GetComponent<Ghost>().Scream();
        }
    }
}
