using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Book : MonoBehaviour, IItem
{
    private TriggerTwoOn stairTriggerDoor;
    public GameObject bookCanvas;
    public GameObject Player;
    private BatteryScript battery;
    private Stand stand;
    private InteractDestroy interactDestroy;
    public Action readBookFirst;
    private bool isOpen = false;
    private bool Once = true;
    private AudioSource walk;
    private bool afterLightOut = false;
    Carpet carpet;

    private void Start() {
        walk = FindObjectOfType<WalkSound>().gameObject.GetComponent<AudioSource>();
        gameObject.layer = 7;
        carpet = FindObjectOfType<Carpet>();
        stairTriggerDoor = FindObjectOfType<TriggerTwoOn>();
        stairTriggerDoor.FirstAction += LayerSetInteract;
        interactDestroy = FindObjectOfType<InteractDestroy>();
        interactDestroy.outCover += () => gameObject.layer = 6;
        carpet.OpenCarpet += () => gameObject.layer = 6;
            
    }
    private void Update() {
        if(isOpen)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                walk.enabled = true;
                Player.GetComponent<FirstPersonController>().enabled = true;
                Player.GetComponent<RayInteraction>().enabled = true;
                bookCanvas.SetActive(false);
                isOpen = false;
            }
        }
    }

    public void LayerSetInteract()
    {
        gameObject.layer = 7;
        afterLightOut = true;
    }

    public void Interact()
    {
        if(isOpen == false && afterLightOut)
        {
            
            if(Once)
            {                

                Once = false;
                battery = FindObjectOfType<BatteryScript>();
                stand = FindObjectOfType<Stand>();
                stand.LayerOn();
                battery.afterReadBook = true;
            }
                walk.enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = false;
            Player.GetComponent<RayInteraction>().enabled = false;
            isOpen = true;
            bookCanvas.SetActive(true);
            
        }
        else if(afterLightOut == false)
        {
            if(Once)
            {
                Once = false;
                battery = FindObjectOfType<BatteryScript>();
                stand = FindObjectOfType<Stand>();
                stand.LayerOn();
                stairTriggerDoor.FirstAction -= LayerSetInteract;
                afterLightOut = true;
                battery.afterReadBook = true;
            }
            walk.enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = false;
            Player.GetComponent<RayInteraction>().enabled = false;
            isOpen = true;
            bookCanvas.SetActive(true);
            readBookFirst();
        }
    }
}
