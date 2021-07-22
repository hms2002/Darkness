using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlusSpecialTrigger : MonoBehaviour
{
    public PlusSpecialDoor plusSpecialDoor;
    public Action specialforstTriggerAction;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(specialforstTriggerAction != null)
            {
                specialforstTriggerAction();
            }
            plusSpecialDoor.AlreadyMove();
            gameObject.SetActive(false);
        }
    }
}
