using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curton : MonoBehaviour, IItem
{
    private GameObject waterSoundPlayer;
    private AudioSource audioSource;
    public AudioClip curtonSound;
    public Animator anim;
    bool isOpen = false;
    bool isOnce = true;
    bool isOn = false;

    private void Start() {
        waterSoundPlayer = GameObject.Find("WaterSoundPlayer");
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        if(isOpen == false && isOn == false)
        {
            isOn = true;
            StartCoroutine("On");
            anim.SetTrigger("OpenTrigger");
            audioSource.PlayOneShot(curtonSound);
            isOpen = true;
        }
        else if(isOpen == true && isOn == false){
            isOn = true;
            StartCoroutine("On");
            anim.SetTrigger("CloseTrigger");
            audioSource.PlayOneShot(curtonSound);
            isOpen = false;
        }
        if(isOnce)
        {
            waterSoundPlayer.GetComponent<WaterSoundPlayer>().StartCoroutine("PlayOff");
            isOnce = false;
        }
    }

    IEnumerator On()
    {
        yield return new WaitForSeconds(0.5f);
        isOn = false;
    }
}
