using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SafeOpen : MonoBehaviour
{
    public static int rightCount;
    public Action safeOpen;
    private Door door;
    private bool isOpen = false;
    private void Start() {
        rightCount = 0;
        door = transform.parent.gameObject.GetComponent<Door>();
    }

    public void Plus()
    {
        rightCount++;
    }
        public void Minus()
    {
        rightCount--;
    }
    public void Interact() {
        if(rightCount == 4)
        {
            Open();
        }
        else{
            Close();
        }
    }
    void Open()
    {
        this.GetComponent<Renderer>().material.color = Color.green;
        door.Interact();
        isOpen = true;
    }
    void Close()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
        if(isOpen == true)
        {
            door.Interact();
            isOpen = false;
        }
    }
}
