using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TriggerTwoOn : MonoBehaviour, IItem
{
    private GameObject triggerTwo;
    private StorageDoor storageDoor;
    public Action FirstAction;

    private Knife knife;
    private bool Once = true;
    private void Start() {
        storageDoor = FindObjectOfType<StorageDoor>();
        knife = FindObjectOfType<Knife>();
    }
    public void Interact()
    {
        if(Once){
            storageDoor.beforeMannequinRoom = true;
            knife.CanGet();
            FirstAction();
            Once = false;
        }
    }
}
