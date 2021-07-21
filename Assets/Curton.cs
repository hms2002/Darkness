using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curton : MonoBehaviour, IItem
{
    private GameObject waterSoundPlayer;
    public Animator anim;
    bool isOpen = false;
    bool isOnce = true;

    private void Start() {
        waterSoundPlayer = GameObject.Find("WaterSoundPlayer");
    }
    public void Interact()
    {
        if(isOpen == false)
        {
            anim.SetTrigger("OpenTrigger");
            isOpen = true;
        }
        else{
            anim.SetTrigger("CloseTrigger");
            isOpen = false;
        }
        if(isOnce)
        {
            waterSoundPlayer.GetComponent<WaterSoundPlayer>().PlayOff();
            isOnce = false;
        }
    }
}
