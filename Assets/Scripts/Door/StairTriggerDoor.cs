using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class StairTriggerDoor : MonoBehaviour, IItem
{
    public bool isTriggerAndDoor = false;
    public bool onceOpen = true;
    public bool isOnlyDoor = true;
    public bool isTriggerAndDoorOn = false;

    public float Rotate = 90/60f;
    public int index =1;
    bool isOpen = false;
    bool ismove = false;
    public AudioClip closeSound2;
    private MainGameSound mainGameSound;
    private TextManager textManager;
    private AudioSource doorSoundPlayer;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip kWANGSound;
    public AudioClip kWANGSound2;
    private GameObject directionLight;
    private triggerOne triggerDelegate;
    private GameObject nextStageWall;
    private GameObject firstTriggerPlus;
    private HandLightOn handLightOn;
    public Action FirstAction;
    private BGM bGM;

    private void Start() {
        mainGameSound = FindObjectOfType<MainGameSound>();
        
        if(transform.GetChild(index).gameObject != null)
        {
            doorSoundPlayer = transform.GetChild(index).gameObject.GetComponent<AudioSource>();
        }
        else
        {
            doorSoundPlayer = GetComponent<AudioSource>();
        }
        textManager = FindObjectOfType<TextManager>();
        triggerDelegate = FindObjectOfType<triggerOne>();
        handLightOn = FindObjectOfType<HandLightOn>();
        bGM = GameObject.Find("BGM").GetComponent<BGM>();
        
        triggerDelegate.TriggerOne += IsDoorTrue;
        directionLight = GameObject.Find("Directional Light");
        nextStageWall = GameObject.Find("NextStageWall");
        firstTriggerPlus = GameObject.Find("FirstTriggerPlus");
    }

    public void Interact()
    {
        if(isTriggerAndDoor || onceOpen || isOnlyDoor)
        {
            StartCoroutine("Thi");
        }
    }
    public void DoorClose()
    {
        StartCoroutine("ICloseDoor");
    }

    public void IsDoorTrue()
    {
        isTriggerAndDoor = true;
        isOnlyDoor = false;
    }

    IEnumerator Thi()
    {
        if(onceOpen)
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

                        yield return new WaitForSeconds(0.007f); 
                    }
                    isOpen = true;
                    ismove = false;
                }
            }
            yield break;
        }
        if(isTriggerAndDoor && isTriggerAndDoorOn == false)
        {
            if(ismove == false)
            {
                ismove = true;
                doorSoundPlayer.PlayOneShot(kWANGSound);
                textManager.DoorTextOn(9);      
                nextStageWall.SetActive(false);
                firstTriggerPlus.SetActive(false);
                yield return new WaitForSeconds(4f);
                doorSoundPlayer.PlayOneShot(kWANGSound2);
                handLightOn.LightOn();
                directionLight.SetActive(false);
                isTriggerAndDoorOn = true;
                bGM.StartRain();
                mainGameSound.SoundStart(); 
                if(FirstAction != null)
                {
                    FirstAction();
                }
                yield return new WaitForSeconds(6f);
                textManager.DoorTextOn(7);
                yield return new WaitForSeconds(3.5f);
                textManager.DoorTextOn(8);
                yield return new WaitForSeconds(3f);
                ismove = false;
            }
        }
        else if(isTriggerAndDoorOn && isTriggerAndDoor)
        {
            if(textManager.isTextOn == false)
            {
                ismove = true;
                doorSoundPlayer.PlayOneShot(kWANGSound);
                textManager.DoorTextOn(1);      
                yield return new WaitForSeconds(2f);
                ismove = false;
            }
        }
        if(isOnlyDoor)
        {
            if(onceOpen == false)
            {
                textManager.DoorTextOn(0);
            }
        }
    }
    IEnumerator ICloseDoor()
    {
        doorSoundPlayer.PlayOneShot(closeSound2);
        for(int i = 0; i < 60; i++)
        {
            transform.Rotate(new Vector3(0, -Rotate, 0));

            yield return new WaitForSeconds(0.007f); 
        }

        while(!(doorSoundPlayer.isPlaying == true))
        {
            yield return new WaitForSeconds(0.01f);
        }
        doorSoundPlayer.PlayOneShot(closeSound);
        ismove = false;
        isOpen = false;
        if(onceOpen) onceOpen = false;
    }
}
