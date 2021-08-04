using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Carpet : MonoBehaviour, IItem
{
    private TriggerTwoOn stairTriggerDoor;
    public GameObject colider;
    public GameObject carpetPaper;
    public Action OpenCarpet;
    Book book;
    private InteractDestroy interactDestroy;
    private bool afterLightOut = false;
    private void Start() {
        gameObject.layer = 7;
        book = FindObjectOfType<Book>();
        interactDestroy = FindObjectOfType<InteractDestroy>();
        stairTriggerDoor = FindObjectOfType<TriggerTwoOn>();
        stairTriggerDoor.FirstAction += LayerSetInteract;
        interactDestroy.outCover += () => gameObject.layer = 6;
        book.readBookFirst += () => gameObject.layer = 6;
    }
    public void LayerSetInteract()
    {
        gameObject.layer = 7;
        afterLightOut = true;
    }
    public void Interact()
    {
        Debug.Log("ds");
        if(afterLightOut == false)
        {
            Debug.Log("dsasdasd");
            stairTriggerDoor.FirstAction -= LayerSetInteract;
            afterLightOut = true;
            OpenCarpet();
        }
        carpetPaper.SetActive(false);
        colider.SetActive(true);
        colider.GetComponent<BoxCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}
