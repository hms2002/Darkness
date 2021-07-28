using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Knife : MonoBehaviour, IItem
{
    private TriggerX hint;
    private AudioSource knifeSound;
    public AudioClip getKnife;
    private Inventory inv;
    private GameObject pibot;
    public event Action getKnifeEvent;
    private TextManager textManager;
    private Inventory inventory;
    public bool canGet = false;
    public bool isHintComplete = false;
    public bool justGotKnifeHint = false;

    private void Start() {
        knifeSound = GetComponent<AudioSource>();
        hint  = FindObjectOfType<TriggerX>();
        inv = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        hint.CanGetWepone += () => isHintComplete = true;
        inventory.useKnife += Dest;
    }
    private void Update() {
        if(inv.isKnife)
        {
            transform.rotation = pibot.transform.rotation;
        }
        else return;
    }//ds
    public void Interact()
    {
        if(canGet && isHintComplete)
        {
            inv.GetKnife();
            getKnifeEvent();
            knifeSound.PlayOneShot(getKnife);
            if(transform.parent != null)
            {
                transform.parent = null;
            }
            this.transform.SetParent(pibot.transform);
            transform.localPosition = new Vector3(0, 0, 0);        
        }
        else if(isHintComplete == false && justGotKnifeHint && textManager.isTextOn == false)
        {
            textManager.OtherTextOn(8);
        }
        else if(textManager.isTextOn == false)
        {
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
