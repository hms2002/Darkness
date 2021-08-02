using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSpecialDoor : MonoBehaviour
{
    public float Rotate = 90/60f;
    bool isOpen = false;
    bool ismove = false;
    bool locked = false;
    public bool AfterMoveStage = false;
    private AudioSource doorSoundPlayer;
    private TriggerSpecial triggerSpecial;
    private TextManager textManager;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip closeSound2;
    public AudioClip kWANGSound;


    private void Start() {
        doorSoundPlayer = GetComponent<AudioSource>();
        textManager = FindObjectOfType<TextManager>();
    }

    public void Interact()
    {
        StartCoroutine("Thi");
    }

    public void AlreadyMove()
    {
        locked = true;

        StartCoroutine("Thi");
        
    }



    IEnumerator Thi()
    {
        if(textManager.isTextOn == false && AfterMoveStage)
        {
            doorSoundPlayer.PlayOneShot(kWANGSound);
            textManager.DoorTextOn(5);
        }

        if(ismove == false && AfterMoveStage == false)
        {
            if(isOpen == false && locked == false)
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
            else if(isOpen == true)
            {
                doorSoundPlayer.PlayOneShot(closeSound2);
                ismove = true;
                for(int i = 0; i < 60; i++)
                {
                    transform.Rotate(new Vector3(0, -Rotate, 0));

                    yield return new WaitForSeconds(0.01f); 
                }

                while(!(doorSoundPlayer.isPlaying == true))
                {
                    yield return new WaitForSeconds(0.01f);
                }
                doorSoundPlayer.PlayOneShot(closeSound);
                ismove = false;
                isOpen = false;
            }
            if(locked)
            {
                AfterMoveStage = true;
            }
        }   
        
    }
}
