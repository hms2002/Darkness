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
    float speed;
    private void Start() {
        waterSoundPlayer = GameObject.Find("WaterSoundPlayer");
        audioSource = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        speed = anim.speed;
        anim.speed = 0.0f;
    }
    public void Interact()
    {
        if(isOnce)
        {
            anim.speed = speed;
            waterSoundPlayer.GetComponent<WaterSoundPlayer>().StartCoroutine("PlayOff");
            isOnce = false;
        }
        if(isOpen == false && isOn == false)
        {
            isOn = true;
            StartCoroutine("On");
            anim.SetTrigger("openTrigger");
            audioSource.PlayOneShot(curtonSound);
            isOpen = true;
        }
        else if(isOpen == true && isOn == false){
            isOn = true;
            StartCoroutine("On");
            anim.SetTrigger("closeTrigger");
            audioSource.PlayOneShot(curtonSound);
            isOpen = false;
        }
    }

    IEnumerator On()
    {
        yield return new WaitForSeconds(0.5f);
        isOn = false;
    }
}
