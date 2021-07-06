using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDesk : MonoBehaviour, IItem
{
    private Meat meat;
    private bool isOnce = true;
    private void Start() {
        meat = FindObjectOfType<Meat>();
    }
    public void Interact()
    {
        if(isOnce)
        {
            meat.SettingMeat();
            isOnce = false;
        }
    }
}
