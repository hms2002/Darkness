using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip mainSound;
    [Range(0,1)] public float volume;
    public void SoundStart()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mainSound;
        audioSource.Play();
        audioSource.loop = true;
        audioSource.volume = volume;
    }

    IEnumerator VolumeUp()
    {
        while(audioSource.volume < volume)
        {
            audioSource.volume += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator VolumeMute()
    {
        while(audioSource.volume > 0)
        {
            audioSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
