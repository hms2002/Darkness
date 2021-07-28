using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour, IItem
{
    private TextManager textManager;
    private AudioSource audioSource;
    public AudioClip clipSound;
    public bool isBatteryOn = false;
    private bool isTextOn = false;
    private bool isLightOn = false;
    public int index;
    
    private void Start() {
        textManager = FindObjectOfType<TextManager>();
        if(transform.GetChild(index).gameObject.GetComponent<AudioSource>() != null)
        {
            audioSource = transform.GetChild(index).gameObject.GetComponent<AudioSource>(); 
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }

        gameObject.layer = 6;
    }

    public void LayerOn()
    {
        gameObject.layer = 7;
    }

    public void Interact()
    {
        if(isBatteryOn == false && textManager.isTextOn == false)
        {
            textManager.OtherTextOn(6);
            audioSource.PlayOneShot(clipSound);
        }
        else if(isBatteryOn)
        {
            if(isLightOn == false)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                audioSource.PlayOneShot(clipSound);
            }
            else{    
                transform.GetChild(0).gameObject.SetActive(false);
                audioSource.PlayOneShot(clipSound);
            }
        }
    }
}
