using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVLightBlink : MonoBehaviour, IItem
{
    private AudioSource TVSoundPlayer;
    public AudioClip TVNoise;
    private bool isOn = true;

    private void Start() {
     TVSoundPlayer = GetComponent<AudioSource>();   
     TVSoundPlayer.clip = TVNoise;
    }

    public void LightBlink()
    {
        TVSoundPlayer.Play(22050);
        StartCoroutine("ITVLightBlinking");
        isOn = true;
    }

    public void Interact()
    {
        if(isOn)
        {
            StopLight();
        }
    }


    IEnumerator ITVLightBlinking()
    {
        while(true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.07f));
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.07f));
        }
    }

    public void StopLight()
    {
        TVSoundPlayer.Stop();
        StopCoroutine("ITVLightBlinking");
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
