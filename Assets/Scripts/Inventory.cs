using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
    public bool isHand = true;
    public bool isKnife = false;
    public bool isGun = false;
    public bool isRope = false;
    public bool isMannquin = false;
    public bool isKey = false;
    public event Action useKnife;
    public event Action useRope;
    public event Action useGun;
    private TextManager textManager;
    private AudioSource WeponePlayer;
    public AudioClip stingSound;
    public AudioClip suspendSound;
    public AudioClip shotSound;

    private void Start() {
        textManager = FindObjectOfType<TextManager>();
        WeponePlayer = GetComponent<AudioSource>();
    }
    public void GetKnife()
    {
        isKnife = true;
        isHand = false;

    }
    public void GetRope()
    {
        isRope = true;
        isHand = false;
        
    }
    public void GetGun()
    {
        isGun = true;
        isHand = false;
        
    }
    public void StingSuspendShot()
    {
        if(isMannquin)
        {
            if(isKnife)
            {
                useKnife();
                isHand = true;
                isKnife = false;
                StartCoroutine("IKnifeSoundPlay");
                return;
            }
            else if(isRope){
                useRope();
                isHand = true;
                isRope = false;
                StartCoroutine("IRopeSoundPlay");
            }
            else if(isGun){
                useGun();
                isHand = true;
                isGun = false;
                StartCoroutine("IGunSoundPlay");
            }
            
        }
    }
    public void isMannequin() {
        if(isKnife)
        {
            textManager.MannequinTextOn(0);
        }
        else if(isRope)
        {
            textManager.MannequinTextOn(1);
        }
        else if(isGun)
        {
            textManager.MannequinTextOn(2);
        }
    }
    IEnumerator IKnifeSoundPlay()
    {
        yield return new WaitForSeconds(1);
        WeponePlayer.PlayOneShot(stingSound);
    }
    IEnumerator IRopeSoundPlay()
    {
        yield return new WaitForSeconds(1);
        WeponePlayer.PlayOneShot(suspendSound);
    }
    IEnumerator IGunSoundPlay()
    {
        yield return new WaitForSeconds(1);
        WeponePlayer.PlayOneShot(shotSound);
    }
}
