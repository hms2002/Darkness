using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Knife : MonoBehaviour, IItem
{
    private AudioSource knifeSound;
    public AudioClip getKnife;
    private Inventory inv;
    private GameObject pibot;
    public event Action getKnifeEvent;
    private TextManager textManager;
    private Inventory inventory;
    public bool canGet = false;

    private void Start() {
        knifeSound = GetComponent<AudioSource>();
        inv = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        inventory.useKnife += Dest;
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
        if(canGet)
        {
            inv.GetKnife();
            getKnifeEvent();
            knifeSound.PlayOneShot(getKnife);
            this.transform.SetParent(pibot.transform);
            transform.localPosition = new Vector3(0, 0, 0);        
        }
        else{
            textManager.OtherTextOn(0);
        }
    }
    public void Dest()
    {
        Destroy(this.gameObject);
        Debug.Log("!2e33");
    }
    public void CanGet()
    {
        canGet = true;
    }
}
