using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSpecialChildDoor : MonoBehaviour, IItem
{
    private PlusSpecialDoor door;
    private void Start() {
        door = transform.parent.gameObject.GetComponent<PlusSpecialDoor>();
    }
    public void Interact()
    {
        door.Interact();
    }
    
}
