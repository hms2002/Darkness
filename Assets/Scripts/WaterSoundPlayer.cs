using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip waterSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOn()
    {
        audioSource.clip = waterSound;
        audioSource.PlayDelayed(0.1f);
        audioSource.loop = true;
    }

    IEnumerator PlayOff()
    {
        while(audioSource.volume > 0)
        {
            audioSource.volume -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();
    }
}
