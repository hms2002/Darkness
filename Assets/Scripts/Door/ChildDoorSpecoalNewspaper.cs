using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDoorSpecoalNewspaper : MonoBehaviour, IItem
{
    private DoorSpecialNewspaper doorSpecialNewspaper;
    void Start()
    {
        doorSpecialNewspaper = FindObjectOfType<DoorSpecialNewspaper>();
    }

    public void Interact()
    {
        doorSpecialNewspaper.Interact();
    }    
}
