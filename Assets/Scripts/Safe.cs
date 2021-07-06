using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour, IItem
{
    public bool isRightPass = true;
    bool isPressed = false;
    public Color pressed;
    public Color Idle; 
    public SafeOpen safeOpen;
    public Inventory inventory;
    private TextManager textManager;
    public bool canUse = false;
    private bool isOn = false;
    
    private void Start() {
        isPressed = false;
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        inventory.useKnife += CanUse;
    }
    public void Interact()
    {
        if(canUse)
        {
            if(isPressed == false)
            {
                if(isRightPass)
                {
                    safeOpen.Plus();
                }
                else safeOpen.Minus();
                this.GetComponent<Renderer>().material.color = pressed;
                isPressed = true;
            }
            else
            {
                if(isRightPass)
                {
                    safeOpen.Minus();
                }
                else safeOpen.Plus();
                this.GetComponent<Renderer>().material.color = Idle;
                isPressed = false;
            }
            safeOpen.Interact();
        }
        else{
            if(isOn == false)
            {
                isOn = true;
                textManager.DoorTextOn(4);
                StartCoroutine("IsOnFalse");
            }
        }
    }
    public void CanUse()
    {
        canUse = true;
    }

    IEnumerator IsOnFalse()
    {
        yield return new WaitForSeconds(2);
        isOn = false;
    }
}
