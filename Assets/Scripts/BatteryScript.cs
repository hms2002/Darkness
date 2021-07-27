using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour, IItem
{
    private Stand stand;
    private TextManager textManager;
    private AudioSource audioSource;
    public AudioClip getBatterySound;
    public bool afterReadBook = false;
    private bool once = true;
    
    public void Interact()
    {
        if(once)
        {
        stand = FindObjectOfType<Stand>();  
        textManager = FindObjectOfType<TextManager>();
        audioSource = FindObjectOfType<AudioSource>();
        }
        if(afterReadBook == false && textManager.isTextOn == false)
        {
            textManager.OtherTextOn(7);
        }
        else if(afterReadBook)
        {
            audioSource.PlayOneShot(getBatterySound);
            stand.isBatteryOn = true;
            gameObject.SetActive(false);
        }
    }
}
