using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class lightZ : MonoBehaviour, IItem
{
    public Action lightOn;
    private bool isOnce = true;

    public void Interact()
    {
        if(isOnce)
        {
            isOnce = false;
            lightOn();
        }
    }
}
