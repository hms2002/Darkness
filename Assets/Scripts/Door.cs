using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IItem
{
    public float Rotate = 90/60f;
    bool isOpen = false;
    bool ismove = false;
    bool isTriggerStart = false;
    bool isTextOn = false;
    private AudioSource doorSoundPlayer;
    private Inventory inventory;
    private TextManager textManager;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip kWANGSound;


    private void Start() {
        doorSoundPlayer = GetComponent<AudioSource>();
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        inventory.useRope += TriggerStart;
    }

    public void Interact()
    {
        StartCoroutine("Thi");
    }
    public void TriggerStart()
    {
        
        isTriggerStart = true;
        if(isOpen == true)
        {
            StartCoroutine("Thi");
        }
    }


    IEnumerator Thi()
    {
        if(isTriggerStart && isOpen == false)
        {
            if(isTextOn == false)
            {
                isTextOn = true;
                doorSoundPlayer.PlayOneShot(kWANGSound);
                textManager.DoorTextOn(5);
                yield return new WaitForSeconds(2.5f);
                isTextOn = false;
            }
        }
        else if(isTriggerStart == false || isOpen == true)
        {
            if(ismove == false)
            {
                if(isOpen == false)
                {
                    doorSoundPlayer.PlayOneShot(openSound);
                    ismove = true;
                    for(int i = 0; i < 60; i++)
                    {
                        transform.Rotate(new Vector3(0, Rotate, 0));

                        yield return new WaitForSeconds(0.01f); 
                    }
                    ismove = false;
                    isOpen = true;
                }
                else
                {
                    doorSoundPlayer.PlayOneShot(closeSound);
                    ismove = true;
                    for(int i = 0; i < 60; i++)
                    {
                        transform.Rotate(new Vector3(0, -Rotate, 0));

                        yield return new WaitForSeconds(0.01f); 
                    }
                    ismove = false;
                    isOpen = false;
                }
            }   
        }
    }
}
