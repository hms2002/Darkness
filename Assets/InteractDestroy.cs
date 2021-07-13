using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDestroy : MonoBehaviour, IItem
{
    private AudioSource audioSource;
    public AudioClip fallSound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        audioSource.PlayOneShot(fallSound);
        gameObject.SetActive(false);
    }    
}
