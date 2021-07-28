using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IItem
{
    public float Rotate = 90/60f;
    public bool isOpen = false;
    bool ismove = false;
    public bool isTriggerStart = false;
    private plusLastSpecialDoor plusLast;
    private AudioSource doorSoundPlayer;
    private TriggerSpecial triggerSpecial;
    private TextManager textManager;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip kWANGSound;
    public int index = 1;

    private void Start() {
        plusLast = FindObjectOfType<plusLastSpecialDoor>();
        if(transform.GetChild(index).gameObject != null)
        {
            transform.GetChild(index).gameObject.GetComponent<AudioSource>();
        }
        else
        {
            doorSoundPlayer = GetComponent<AudioSource>();
        }
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
            if(textManager.isTextOn == false)
            {
                doorSoundPlayer.PlayOneShot(kWANGSound);
                textManager.DoorTextOn(5);
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
