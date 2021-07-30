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
    public bool isKnifeGet = false;

    private void Start() {
        knifeSound = GetComponent<AudioSource>();
        hint  = FindObjectOfType<TriggerX>();
        inv = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        hint.CanGetWepone += () => isHintComplete = true;
        // inventory.useKnife += Dest;
    }
    private void Update() {
    }//ds
    public void Interact()
    {
        if(isKnifeGet == true)
        {
            return;
        }

        if(canGet && isHintComplete)
        {
            isKnifeGet = true;
            inv.GetKnife();
            getKnifeEvent();
             knifeSound.PlayOneShot(getKnife);
            // if(transform.parent.parent != null)
            // {
            //     transform.parent.parent = null;
            // }
            // transform.parent.SetParent(pibot.transform);
            // transform.parent.localPosition = new Vector3(0, 0, 0);  
            gameObject.GetComponent<MeshRenderer>().enabled = false;   
            Destroy(transform.parent.gameObject, 3f);   
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
        Destroy(transform.parent.gameObject);
        Debug.Log("!2e33");
    }
    public void CanGet()
    {
        canGet = true;
    }
}
