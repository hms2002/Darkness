using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundplay : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ButtonSound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        audioSource.PlayOneShot(ButtonSound);
    }
}
