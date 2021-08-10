using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SafeUIManager : MonoBehaviour, IItem
{
    private GameManager gameManager;
    public GameObject game;
    private GameObject Player;
    private AudioSource walkSound;
    private AudioSource audioSource;
    public AudioClip openSafeSound;
    public AudioClip closeSafeSound;
    private PassManager Pass;
    private TextManager textManager;
    private Inventory inventory;
    private Door door;
    public Action BackAction;
    public Action SafeOpenAction;
    bool UION = false;
    public bool atFirst = true;
    public bool canUse = false;
    public bool isOpen = false;
    private bool isOn = false;
    
    private void Start() {
        walkSound = FindObjectOfType<WalkSound>().gameObject.GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        Player = GameObject.FindWithTag("Player");
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
                
                walkSound.enabled = false;
                gameManager.isCanESC = false;
                game.SetActive(true);
                Pass = FindObjectOfType<PassManager>();
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponent<RayInteraction>().enabled = false;
                textManager.TextClose();
                audioSource = GetComponent<AudioSource>();
                Cursor.lockState = CursorLockMode.Confined;
                UION = true;
            
            }
            else{
                if(atFirst)
                {
                    atFirst = false;
                    BackAction();
                }
                door.Interact();
            }
        }
        else
        {
            if(textManager.isTextOn == false)
            {
                textManager.DoorTextOn(4);
            }
        }
    }
    private void Update() {
        if(UION)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
            {
                CloseUI();
                gameManager.isCanESC = true;
            }
        }
    }
    public void CloseUI()
    {
        walkSound.enabled = true;
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
