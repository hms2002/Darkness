using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTwoOn : MonoBehaviour, IItem
{
    private GameObject triggerTwo;
    private GameObject triggerFour;
    private StorageDoor storageDoor;

    private Knife knife;
    private bool Once = true;
    private void Start() {
        storageDoor = FindObjectOfType<StorageDoor>();
        triggerFour = GameObject.Find("TriggerFour");
        knife = FindObjectOfType<Knife>();
    }
    public void Interact()
    {
        if(Once){
            storageDoor.beforeMannequinRoom = true;
            triggerFour.gameObject.SetActive(true);
            knife.CanGet();
            Once = false;
        }
    }
}
