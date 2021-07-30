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
    private bool youUseKnife = false;
    public bool beforeMannequinRoom = false;
    void Start()
    {
        KwangSoundPlayer = GetComponent<AudioSource>();
        inventory = FindObjectOfType<Inventory>();
        textManager = FindObjectOfType<TextManager>();
        door = transform.parent.gameObject.GetComponent<Door>();
        inventory.useKnife += YouUseKnife;
    }

    public void Interact()
    {
        if(beforeMannequinRoom == false)
        {
            if(textManager.isTextOn == false)
            {
                KwangSoundPlayer.PlayOneShot(KwangSound);
                textManager.DoorTextOn(5);
                StartCoroutine("IsOnFalse");
            }
        }
        else
        {
            if(inventory.isKey == false && youUseKnife == false)
            {
                if(textManager.isTextOn == false)
                {
                    KwangSoundPlayer.PlayOneShot(KwangSound);
                    textManager.DoorTextOn(5);
                }
            }
            else if(inventory.isKey == false && youUseKnife)
            {
                if(textManager.isTextOn == false)
                {
                    KwangSoundPlayer.PlayOneShot(KwangSound);
                    textManager.DoorTextOn(2);
                    StartCoroutine("IDoorHint");
                }
            }
            else{
                door.Interact();
            }
        }
    }
    public void YouUseKnife()
    {
        youUseKnife = true;
    }
    IEnumerator IDoorHint()
    {
        yield return new WaitForSeconds(4f);
        textManager.DoorTextOn(3);
    }
}
