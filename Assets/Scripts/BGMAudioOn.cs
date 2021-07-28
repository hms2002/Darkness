using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BGMAudioOn : MonoBehaviour, IItem
{
    private plusLastSpecialDoor lastSpecialDoor;
    private AudioSource audioSource;
    public AudioClip BGMSound;
    public float SoundMax = 0.1f;
    private bool isOnce = true;
    void Start()
    {
        lastSpecialDoor = FindObjectOfType<plusLastSpecialDoor>();
        audioSource = GetComponent<AudioSource>();
        lastSpecialDoor.lightOut2 += Off;
    }

    public void Interact()
    {
        if(isOnce)
        {
            audioSource.volume = 0;
            audioSource.clip = BGMSound;
            audioSource.loop = true;
            StartCoroutine("Up");
            audioSource.Play();
            isOnce = false;
        }
    }

    public void Off()
    {
        StartCoroutine("IOff");
    }

    IEnumerator IOff()
    {
        while(audioSource.volume > 0)
        {
            audioSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        audioSource.Stop();
    }

    IEnumerator Up()
    {
        while(audioSource.volume <= SoundMax)
        {
            audioSource.volume += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
