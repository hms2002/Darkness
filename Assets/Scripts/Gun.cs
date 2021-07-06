using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IItem
{
    private GameObject pibot;
    private Inventory inventory;
    private AudioSource getGunSoundPlayer;
    public AudioClip getGunSound;
    private void Start() {
        getGunSoundPlayer = GetComponent<AudioSource>();
        inventory = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
        inventory.useGun += Dest;
    }
    public void Interact()
    {
        inventory.GetGun();
        this.transform.SetParent(pibot.transform);
        transform.localPosition = new Vector3(0, 0, 0); 
        getGunSoundPlayer.PlayOneShot(getGunSound);
    }
    public void Dest()
    {
        Destroy(this);
    }
}
