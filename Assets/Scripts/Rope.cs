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

    private void Start() {
        RopeSound = GetComponent<AudioSource>();
        inv = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
        textManager = FindObjectOfType<TextManager>();
        inv.useRope += Dest;//ds
    }
    private void Update() {
        if(inv.isRope)
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
        transform.transform.SetParent(pibot.transform);
        transform.localPosition  = new Vector3(0,0,0);
        
    }
    public void Dest()
    {
        Destroy(transform.parent.gameObject);
        Debug.Log("!2e33");
    }
}
