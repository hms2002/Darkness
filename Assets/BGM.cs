using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip rain;
    public float SoundMaxVol = 0.95f;
    public float SoundSmallVol = 0.4f;
    public float UpSpeed = 0.005f;
    public float DownSpeed = 0.01f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
        audioSource.clip = rain;
    }
    
    public void StartRain()
    {
        StartCoroutine("IStartRain");
    }

    IEnumerator IStartRain()
    {
        audioSource.PlayDelayed(1f);
        audioSource.loop = true;
        while(audioSource.volume <= SoundMaxVol)
        {
            audioSource.volume += 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(UpSpeed);
        }
        while(audioSource.volume > SoundSmallVol)
        {
            audioSource.volume -= 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(DownSpeed);
        }
    }
}
