using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HintManager : MonoBehaviour
{
    private TextManager textManager;
    public GameObject KnifeSprite;
    public GameObject RopeSprite;
    public GameObject GunSprite;
    public GameObject ExitSprite;
    private Knife knife;
    public bool KnifeHintOn = false;
    public bool RopeHintOn = false;
    public bool GunHintOn = false;
    private int cnt = 0;

    private GameObject triggerX;
    public GameObject whisperObj;
    private AudioSource audioSource;
    public AudioClip whisper;

    private void Start() {
        knife = FindObjectOfType<Knife>();
        textManager = FindObjectOfType<TextManager>();
        audioSource = whisperObj.GetComponent<AudioSource>();

        triggerX = GameObject.Find("TriggerX");
    }

    public void GetHint(int num)
    {
        switch(num)
        {
            case 1:
            KnifeHintOn = true;
            knife.justGotKnifeHint = true;
            KnifeSprite.SetActive(true);
            cnt++;
            break;
            case 2:
            RopeHintOn = true;
            RopeSprite.SetActive(true);
            cnt++;
            break;
            case 3:
            GunHintOn = true;
            GunSprite.SetActive(true);
            cnt++;
            break;
        }
        if(KnifeHintOn && RopeHintOn && GunHintOn)
        {
            knife.justGotKnifeHint = false;
            ExitSprite.SetActive(true);
            StartCoroutine("fasd");
            triggerX.gameObject.SetActive(true);
        }
        if(cnt == 2)
        {
            audioSource.PlayOneShot(whisper);
        }
    }

    IEnumerator fasd()
    {
        yield return new WaitForSeconds(3f);
        textManager.OtherTextOn(11);
        yield return new WaitForSeconds(3f);
        textManager.OtherTextOn(12);

    }
}
