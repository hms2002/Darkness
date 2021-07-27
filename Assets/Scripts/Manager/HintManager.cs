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

    public Action CanGetWepone;
    private GameObject triggerFour;

    private void Start() {
        knife = FindObjectOfType<Knife>();
        textManager = FindObjectOfType<TextManager>();
        triggerFour = GameObject.Find("TriggerFour");
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
            CanGetWepone();
            ExitSprite.SetActive(true);
            textManager.OtherTextOn(11);
            triggerFour.gameObject.SetActive(true);
        }
    }
}
