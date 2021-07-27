using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChildDoor : MonoBehaviour,IItem
{
    private plusLastSpecialDoor lastSpecialDoor;
    // Start is called before the first frame update
    void Start()
    {
        lastSpecialDoor = FindObjectOfType<plusLastSpecialDoor>();
    }


    public void Interact()
    {
    }
}
