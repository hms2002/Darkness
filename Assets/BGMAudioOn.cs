using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMAudioOn : MonoBehaviour, IItem
{
    private AudioSource audioSource;
    public AudioClip BGMSound;
    public float SoundMax = 0.1f;
    private bool isOnce = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    IEnumerator Up()
    {
        while(audioSource.volume <= SoundMax)
        {
            audioSource.volume += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
