using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorBethRoomDoor : MonoBehaviour, IItem
{
    private FirstFloorBethRoomDoorPibot firstFloorBethRoomDooePibot;

    private Door door;
    private TextManager textManager;
    private AudioSource KwangSoundPlayer;
    public AudioClip KwangSound;
    public AudioClip DoorOpenSound;
    public bool isTriggerOn = false;
    private bool isOn = false;
    public bool isLittelOpen = false;
    private void Start() {
        door = transform.parent.gameObject.GetComponent<Door>();
        firstFloorBethRoomDooePibot = transform.parent.gameObject.GetComponent<FirstFloorBethRoomDoorPibot>();
        KwangSoundPlayer = GetComponent<AudioSource>();
        textManager = FindObjectOfType<TextManager>();
    }
    public void Interact()
    {

        if(isTriggerOn)
        {
            if(isOn == false)
            {
                isOn = true;
                KwangSoundPlayer.PlayOneShot(KwangSound);
                textManager.DoorTextOn(5);
                StartCoroutine("IsOnFalse");
            }
        }
        else
        {
            if(isLittelOpen)
            {
                isLittelOpen = false;
                firstFloorBethRoomDooePibot.Interact();
                KwangSoundPlayer.PlayOneShot(DoorOpenSound);
                door.isOpen = true;
            }
            else
            {
                door.Interact();
            }
        }
    }

    IEnumerator IsOnFalse()
    {
        yield return new WaitForSeconds(2);
        isOn = false;
    }
}
