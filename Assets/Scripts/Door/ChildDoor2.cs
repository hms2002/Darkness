using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDoor2 : MonoBehaviour, IItem
{
    public StairTriggerDoor door;
    public void Interact()
    {
        door.Interact();
    }
}
