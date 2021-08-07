using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotShotInRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Inventory.isInRoom = true;
            Debug.Log("In");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            Inventory.isInRoom = false;
            Debug.Log("Out");
        }
    }
}