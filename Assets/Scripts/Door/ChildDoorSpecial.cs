using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDoorSpecial : MonoBehaviour, IItem
{
    private StairTriggerDoor door;
    private void Start() {
        door = FindObjectOfType<StairTriggerDoor>();
    }
    public void Interact()
    {
        door.Interact();
    }
    
}
