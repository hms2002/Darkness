using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour, IItem
{
    private AudioSource KwangSoundPlayer;
    public AudioClip KwangSound;
    private Inventory inventory;
    private TextManager textManager;
    private Door door;
    private bool isOn = false;
    void Start()
    {
        KwangSoundPlayer = GetComponent<AudioSource>();
        inventory = FindObjectOfType<Inventory>();
        textManager = FindObjectOfType<TextManager>();
        door = transform.parent.gameObject.GetComponent<Door>();
    }

    public void Interact()
    {
        if(inventory.isKey == false)
        {
            if(isOn == false)
            {
                isOn = true;
                KwangSoundPlayer.PlayOneShot(KwangSound);
                textManager.DoorTextOn(2);
                StartCoroutine("IDoorHint");
            }
        }
        else{
            door.Interact();
        }
    }
    IEnumerator IDoorHint()
    {
        yield return new WaitForSeconds(2.5f);
        textManager.DoorTextOn(3);
        isOn = false;
    }
}
