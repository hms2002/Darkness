using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IItem
{
    private Inventory inventory;
    private AudioSource KeySoundPlayer;
    public AudioClip KeySound;

    private void Start() {
        inventory = FindObjectOfType<Inventory>();
        KeySoundPlayer = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        KeySoundPlayer.PlayOneShot(KeySound);
        inventory.isKey = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    
    }
}
