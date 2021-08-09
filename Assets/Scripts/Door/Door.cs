using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IItem
{
    public float Rotate = 90/60f;
    public bool isOpen = false;
    bool ismove = false;
    public bool isTriggerStart = false;
    public int ZeroIsBigDoor = 0;
    private plusLastSpecialDoor plusLast;
    private AudioSource doorSoundPlayer;
    private TriggerSpecial triggerSpecial;
    private TextManager textManager;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip closeSound2;
    public AudioClip kWANGSound;
    public int index = 1;

    private void Start() {
        plusLast = FindObjectOfType<plusLastSpecialDoor>();
        if(transform.GetChild(index).gameObject.GetComponent<AudioSource>() != null)
        {
            doorSoundPlayer = transform.GetChild(index).gameObject.GetComponent<AudioSource>();
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
        Debug.Log("단계 1 : 연결 됨");
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
        Debug.Log("단계 2 : 코루틴 실행 됨");
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
                Debug.Log("단계 4 : 안 움직임");
                if(isOpen == false)
                {
                    doorSoundPlayer.PlayOneShot(openSound);
                    ismove = true;
                    for(int i = 0; i < 60; i++)
                    {
                        transform.Rotate(new Vector3(0, Rotate, 0));

                        yield return new WaitForSeconds(0.007f); 
                    }
                    Debug.Log("단계 5 : 잘 열림");
                    ismove = false;
                    isOpen = true;
                }
                else
                {
                    Debug.Log("단계 4 : 안 움직임");
                    doorSoundPlayer.PlayOneShot(closeSound2);
                    ismove = true;
                    for(int i = 0; i < 60; i++)
                    {
                        transform.Rotate(new Vector3(0, -Rotate, 0));

                        yield return new WaitForSeconds(0.007f); 
                    }

                    while((doorSoundPlayer.isPlaying == true))
                    {
                        yield return new WaitForSeconds(0.01f);
                    }
                    switch(ZeroIsBigDoor)
                    {
                        case 0:
                            doorSoundPlayer.PlayOneShot(closeSound);
                        break;
                        default:
                        break;
                    }
                    Debug.Log("단계 5 : 잘 닫힘");
                    ismove = false;
                    isOpen = false;
                }
            }   
        }
    }
}
