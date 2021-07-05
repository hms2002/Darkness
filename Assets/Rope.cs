using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rope : MonoBehaviour, IItem
{
    private AudioSource RopeSound;
    public AudioClip getRope;
    private Inventory inv;
    private GameObject pibot;
    public event Action getRopeEvent;
    private TextManager textManager;
    private Inventory inventory;

    private void Start() {
        RopeSound = GetComponent<AudioSource>();
        inv = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        inventory.useRope += Dest;
    }
    private void Update() {
        if(inv.isKnife)
        {
            transform.rotation = pibot.transform.rotation;
        }
        else return;
    }
    public void Interact()
    {
        inv.GetRope();
        //getRopeEvent();
        RopeSound.PlayOneShot(getRope);
        this.transform.SetParent(pibot.transform);
        transform.localPosition = new Vector3(0, 0, 0);        
        
    }
    public void Dest()
    {
        Destroy(this.gameObject);
        Debug.Log("!2e33");
    }
}
