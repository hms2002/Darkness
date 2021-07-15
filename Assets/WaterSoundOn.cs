using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundOn : MonoBehaviour, IItem
{
    private GameObject waterSoundPlayer;
    private bool isOnce = true;
    private void Start() {
        waterSoundPlayer = GameObject.Find("WaterSoundPlayer");
    }
    public void Interact()
    {
        if(isOnce)
        {
            waterSoundPlayer.GetComponent<WaterSoundPlayer>().PlayOn();
            isOnce = false;
        }
    }
}
