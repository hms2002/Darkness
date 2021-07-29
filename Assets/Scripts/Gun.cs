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
        getGunSoundPlayer = transform.parent.parent.gameObject.GetComponent<AudioSource>();
        inventory = FindObjectOfType<Inventory>();
        pibot = GameObject.Find("WeponPibot");
    }
    public void Interact()
    {
        inventory.GetGun();
        getGunSoundPlayer.PlayOneShot(getGunSound);
        Destroy(transform.parent.gameObject);
    }
    public void Dest()
    {
        Destroy(this);
    }
}
