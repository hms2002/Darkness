using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curton : MonoBehaviour, IItem
{
    private GameObject waterSoundPlayer;

    private void Start() {
        waterSoundPlayer = GameObject.Find("WaterSoundPlayer");
    }
    public void Interact()
    {
        waterSoundPlayer.GetComponent<WaterSoundPlayer>().PlayOff();
    }
}
