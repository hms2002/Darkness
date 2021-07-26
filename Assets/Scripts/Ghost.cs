using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private FirstFloorBethRoomDoor first;
    public FirstFloorBethRoomDoorPibot firstFloorBethRoomDooePibot;
    private AudioSource screamSoundPlayer;
    public AudioClip OpenSound;
    public AudioClip CrySound;
    private Knife knife;
    public bool alreadyDest = false;
    void Start()
    {
        first = FindObjectOfType<FirstFloorBethRoomDoor>();
        firstFloorBethRoomDooePibot = FindObjectOfType<FirstFloorBethRoomDoorPibot>();
        screamSoundPlayer = GetComponent<AudioSource>();
        StartCoroutine("StartFalse");
        knife = FindObjectOfType<Knife>();
        knife.getKnifeEvent += Scream;
    }

    public void Scream()
    {
        StartCoroutine("ScreamIEnum");
        if(alreadyDest)
        {
            knife.getKnifeEvent -= Scream;
        }
    }
    public void Cry()
    {
        screamSoundPlayer.PlayOneShot(CrySound);
    }

    IEnumerator ScreamIEnum()
    {
        firstFloorBethRoomDooePibot.StartCoroutine("Thi");
        screamSoundPlayer.PlayOneShot(OpenSound);
        first.isTriggerOn = false;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }
    IEnumerator StartFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
