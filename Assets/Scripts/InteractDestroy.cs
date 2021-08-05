using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InteractDestroy : MonoBehaviour, IItem
{
    private AudioSource audioSource;
    public AudioClip fallSound;
    private TriggerTwoOn stairTriggerDoor;
    public GameObject canvas;
    public Action outCover;
    Book book;
    Carpet carpet;
    private bool isAfterDark = false;
    private void Start() {
        carpet = FindObjectOfType<Carpet>();
        audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        stairTriggerDoor = FindObjectOfType<TriggerTwoOn>();
        book = FindObjectOfType<Book>();
        gameObject.layer = 7;
        stairTriggerDoor.FirstAction += LayerSetInteract;

        book.readBookFirst += () => gameObject.layer = 6;
        carpet.OpenCarpet += () => gameObject.layer = 6;
    }   


    public void LayerSetInteract()
    {
        gameObject.layer = 7;
        isAfterDark = true;
        Debug.Log("aa");
    }
    public void Interact()
    {
        if(isAfterDark == false)
        {
            stairTriggerDoor.FirstAction -= LayerSetInteract;
            outCover();
            isAfterDark = true;
        }
        canvas.SetActive(true);
        audioSource.PlayOneShot(fallSound);
        gameObject.SetActive(false);
    }    
}
