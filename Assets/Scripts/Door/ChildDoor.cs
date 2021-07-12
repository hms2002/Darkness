using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDoor : MonoBehaviour, IItem
{
    private Door door;
    private void Start() {
        door = transform.parent.gameObject.GetComponent<Door>();
    }
    public void Interact()
    {
        door.Interact();
    }
    
}
