using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SafeUIManager : MonoBehaviour, IItem
{
    public GameObject game;
    private GameObject Player;
    private AudioSource audioSource;
    public AudioClip openSafeSound;
    public AudioClip closeSafeSound;
    private PassManager Pass;
    private TextManager textManager;
    private Inventory inventory;
    private Door door;
    public Action SafeOpenAction;
    bool UION = false;
    public bool canUse = false;
    public bool isOpen = false;
    private bool isOn = false;
    private void Start() {
        Player = GameObject.Find("Player");
        textManager = FindObjectOfType<TextManager>();
        door = transform.parent.gameObject.GetComponent<Door>();
        inventory = FindObjectOfType<Inventory>();
        inventory.useKnife += CanUse;
    }
    public void Interact()
    {
        if(canUse)
        {
            if(isOpen == false)
            {
                UION = true;
                game.SetActive(true);
                Pass = FindObjectOfType<PassManager>();
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<RayInteraction>().enabled = false;
                audioSource = GetComponent<AudioSource>();
                Cursor.lockState = CursorLockMode.Confined;
            }
            else{
                door.Interact();
            }
        }
        else
        {
            if(isOn == false)
            {
                isOn = true;
                textManager.DoorTextOn(4);
                StartCoroutine("IsOnFalse");
            }
        }
    }
    private void Update() {
        if(UION)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                CloseUI();
            }
        }
    }
    public void CloseUI()
    {
        Pass.Reseting();
        Pass = null;
        UION = false;
        game.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        Player.GetComponent<RayInteraction>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Open()
    {
        CloseUI();
        SafeOpenAction();
    }
    public void CanUse()
    {
        canUse = true;
    }

    IEnumerator IsOnFalse()
    {
        yield return new WaitForSeconds(2);
        isOn = false;
    }
}
