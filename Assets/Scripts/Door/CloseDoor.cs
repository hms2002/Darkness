using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    private StairTriggerDoor stairTriggerDoor;
    private void Start() {
        stairTriggerDoor = FindObjectOfType<StairTriggerDoor>();
    }
    private void OnTriggerEnter(Collider other) {
        stairTriggerDoor.DoorClose();
        gameObject.SetActive(false);
    }
}
