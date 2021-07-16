using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPibot4Sound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip CrackSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Playing()
    {
        audioSource.PlayOneShot(CrackSound);
    }
}
