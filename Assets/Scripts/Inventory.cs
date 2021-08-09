using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
    public static bool isInRoom = false;
    public bool isHand = true;
    public bool isKnife = false;
    public bool isGun = false;
    public bool isRope = false;
    public bool isMannquin = false;
    public bool isKey = false;
    public GameObject Gun;
    private FirstPersonController firstPersonController;
    private RayInteraction rayInteraction;
    public event Action useKnife;
    public event Action useRope;
    public event Action useGun;
    private TextManager textManager;
    private AudioSource WeponePlayer;
    public AudioClip stingSound;
    public AudioClip suspendSound;
    public AudioClip shotSound;
    private Camera playerCam;
    public Animator anim;

    private void Start() {
        playerCam = Camera.main;
        firstPersonController = FindObjectOfType<FirstPersonController>();
        rayInteraction = FindObjectOfType<RayInteraction>();
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
        Gun.SetActive(true);
        isGun = true;
        isHand = false;
        
    }
    public void StingSuspendShot()
    {
        if(isMannquin)
        {
            if(isKnife)
            {
                textManager.TextClose();
                useKnife();
                isHand = true;
                isKnife = false;
                firstPersonController.enabled = false;
                rayInteraction.enabled = false;
                StartCoroutine("IKnifeSoundPlay");
                return;
            }
            else if(isRope){
                textManager.TextClose();
                useRope();
                isHand = true;
                isRope = false;
                firstPersonController.enabled = false;
                rayInteraction.enabled = false;
                StartCoroutine("IRopeSoundPlay");
            }
            
        }
    }

    public void StingSuspendShot2(float distance)
    {
        if(isMannquin)
        {
            if(isGun)
            {
                if(isInRoom == false)
                {

                    if(distance > 12.5)
                    {
                        textManager.TextClose();
                        useGun();
                        isHand = true;
                        isGun = false;
                        firstPersonController.enabled = false;
                        rayInteraction.enabled = false;
                        StartCoroutine("IGunSoundPlay");
                    }
                    else
                    {
                        if(textManager.isTextOn == false)
                        textManager.OtherTextOn(18);
                    }
                }
                else
                {
                    if(textManager.isTextOn == false)
                    textManager.OtherTextOn(19);
                }
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
    }

    public void isMannequin2(float distance) {
        if(isGun)
        {
            anim.SetLayerWeight(5, 1f);
            anim.SetTrigger("Aiming");
            if(isInRoom == false)
            {
                if(distance > 12.5)
                {
                    if(textManager.isTextOn == false)
                    {
                        textManager.text.color = Color.red;
                        textManager.MannequinTextOn(2);
                    }
                }
                else
                {
                    textManager.text.color = Color.white;
                    textManager.MannequinTextOn(2);
                }
            }
            else
            {
                textManager.text.color = Color.white;
                textManager.MannequinTextOn(2);
            }
        }
    }

    IEnumerator IKnifeSoundPlay()
    {
        yield return new WaitForSeconds(1);
        WeponePlayer.PlayOneShot(stingSound);
        firstPersonController.enabled = true;
        rayInteraction.enabled = true;
    }
    IEnumerator IRopeSoundPlay()
    {
        yield return new WaitForSeconds(1);
        WeponePlayer.PlayOneShot(suspendSound);
        firstPersonController.enabled = true;
        rayInteraction.enabled = true;
    }
    IEnumerator IGunSoundPlay()
    {
        yield return new WaitForSeconds(1);
        WeponePlayer.PlayOneShot(shotSound);
    }
}
