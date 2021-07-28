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

    private GameObject triggerX;

    private void Start() {
        knife = FindObjectOfType<Knife>();
        textManager = FindObjectOfType<TextManager>();
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
            break;
            case 2:
            RopeHintOn = true;
            RopeSprite.SetActive(true);
            break;
            case 3:
            GunHintOn = true;
            GunSprite.SetActive(true);
            break;
        }
        if(KnifeHintOn && RopeHintOn && GunHintOn)
        {
            knife.justGotKnifeHint = false;
            ExitSprite.SetActive(true);
            StartCoroutine("fasd");
            triggerX.gameObject.SetActive(true);
        }
    }

    IEnumerator fasd()
    {
        yield return new WaitForSeconds(3f);
        textManager.OtherTextOn(11);
        yield return new WaitForSeconds(5f);
        textManager.OtherTextOn(12);

    }
}
