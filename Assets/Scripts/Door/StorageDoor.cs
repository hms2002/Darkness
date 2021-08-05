using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour, IItem
{
    private AudioSource KwangSoundPlayer;
    public AudioClip KwangSound;
    public AudioClip klurk;
    private Inventory inventory;
    private TextManager textManager;
    private Door door;
    private bool Once = true;
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
                if(Once)
                {
                    Once = false;
                    KwangSoundPlayer.PlayOneShot(klurk);
                    return;
                }
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
