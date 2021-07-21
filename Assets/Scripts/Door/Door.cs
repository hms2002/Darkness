using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IItem
{
    public float Rotate = 90/60f;
    bool isOpen = false;
    bool ismove = false;
    public bool isTriggerStart = false;
    bool isTextOn = false;
    private plusLastSpecialDoor plusLast;
    private AudioSource doorSoundPlayer;
    private TriggerSpecial triggerSpecial;
    private TextManager textManager;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip kWANGSound;


    private void Start() {
        plusLast = FindObjectOfType<plusLastSpecialDoor>();
        doorSoundPlayer = GetComponent<AudioSource>();
        textManager = FindObjectOfType<TextManager>();
        triggerSpecial = FindObjectOfType<TriggerSpecial>();
        triggerSpecial.doorOff += TriggerStart;
        if(plusLast != null)
        {
            plusLast.goAnotherWorld2 += TriggerEnd;
        }
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

    public void TriggerEnd()
    {
        isTriggerStart = false;
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
