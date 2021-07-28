using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpecialNewspaper : MonoBehaviour, IItem
{
    public float Rotate = 90/60f;
    bool isOpen = false;
    bool ismove = false;
    bool isTriggerStart = false;
    bool onceOpen = true;
    bool isOnceOpenLock = false;
    private AudioSource doorSoundPlayer;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip kWANGSound;
    private TextManager textManager;
    private TriggerSpecial triggerSpecial;
    private plusLastSpecialDoor plusLast;
    private void Start() {
        plusLast = FindObjectOfType<plusLastSpecialDoor>();
        textManager = FindObjectOfType<TextManager>();
        doorSoundPlayer = GetComponent<AudioSource>();
        triggerSpecial = FindObjectOfType<TriggerSpecial>();
        triggerSpecial.doorOff += TriggerStart;
        if(plusLast != null)
        {
            plusLast.goAnotherWorld2 += TriggerEnd;
        }

    }
    public void Interact()
    {
        StartCoroutine("InteractDoor");
    }

    public void TriggerStart()
    {
        isTriggerStart = true;
        if(isOpen == true)
        {
            StartCoroutine("InteractDoor");
        }
    }

    public void TriggerEnd()
    {
        isTriggerStart = false;
    }
    public void OnceOpenOff()
    {
        if(isOpen == true)
        {
            StartCoroutine("InteractDoor");
        }
        else
        {
            onceOpen = false;
        }
        isOnceOpenLock = true;
    }

    IEnumerator InteractDoor()
    {
        if(isTriggerStart == false || onceOpen)
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
                    if(isOnceOpenLock)
                    {
                        onceOpen = false;
                    }
                    ismove = false;
                    isOpen = false;
                }
            }
        }
        else{
            if(textManager.isTextOn == false)
            {
                doorSoundPlayer.PlayOneShot(kWANGSound);
                textManager.DoorTextOn(5);
            }
        }
    }


}
