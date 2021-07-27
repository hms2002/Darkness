using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundOn : MonoBehaviour, IItem
{
    private GameObject waterSoundPlayer;
    private bool isOnce = true;
    private bool isTriggerStart;
    private void Start() {
        waterSoundPlayer = GameObject.Find("WaterSoundPlayer");
        
    }
    public void Interact()
    {
        if(isOnce && transform.parent.GetComponent<Door>().isTriggerStart == false)
        {
            waterSoundPlayer.GetComponent<WaterSoundPlayer>().PlayOn();
            isOnce = false;
        }
    }
}
