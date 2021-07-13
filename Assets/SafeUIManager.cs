using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeUIManager : MonoBehaviour, IItem
{
    public GameObject game;
    private GameObject Player;
    private AudioSource audioSource;
    public AudioClip openSafeSound;
    public AudioClip closeSafeSound;
    bool UION = false;
    public bool isOpen = false;
    private void Start() {
        Player = GameObject.Find("Player");
    }
    public void Interact()
    {
        if(isOpen == false)
        {
            UION = true;
            game.SetActive(true);
            Player.GetComponent<FirstPersonController>().enabled = false;
            Player.GetComponent<RayInteraction>().enabled = false;
            audioSource = GetComponent<AudioSource>();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else{

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
        UION = false;
        game.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        Player.GetComponent<RayInteraction>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Open()
    {
        audioSource.PlayOneShot(openSafeSound);
        isOpen = true;
    }
}
