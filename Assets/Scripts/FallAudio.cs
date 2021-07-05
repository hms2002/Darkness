using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAudio : MonoBehaviour
{
    public AudioClip fallAudioClip;
    private AudioSource fallAudioPlayer;    
    void Start()
    {
        fallAudioPlayer = GetComponent<AudioSource>();
    }

    public void Play()
    {
        fallAudioPlayer.PlayOneShot(fallAudioClip);
    }
}
