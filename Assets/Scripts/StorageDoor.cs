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
    private bool youUseKnife = false;
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
        if(inventory.isKey == false && youUseKnife == false)
        {
            if(isOn==false)
            {
                isOn = true;
                KwangSoundPlayer.PlayOneShot(KwangSound);
                textManager.DoorTextOn(4);
                StartCoroutine("IsOnFalse");
            }
        }
        else if(inventory.isKey == false && youUseKnife)
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
    public void YouUseKnife()
    {
        youUseKnife = true;
    }

    IEnumerator IsOnFalse()
    {
        yield return new WaitForSeconds(2);
        isOn = false;
    }

    IEnumerator IDoorHint()
    {
        yield return new WaitForSeconds(2.5f);
        textManager.DoorTextOn(3);
        isOn = false;
    }
}
