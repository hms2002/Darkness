using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVLightBlink : MonoBehaviour, IItem
{
    private AudioSource TVSoundPlayer;
    public AudioClip TVNoise;
    public AudioClip CheckOn;
    private TextManager textManager;
    private bool isOn = true;
    private bool isTextOn = false;

    private void Start() {
     textManager = FindObjectOfType<TextManager>();
     TVSoundPlayer = GetComponent<AudioSource>();   
     TVSoundPlayer.clip = TVNoise;
    }

    public void LightBlink()
    {
        TVSoundPlayer.Play(22050);
        TVSoundPlayer.loop = true;
        StartCoroutine("ITVLightBlinking");
        isOn = true;
    }

    public void Interact()
    {
        if(isOn)
        {
            StopLight();
        }
        else
        {
            if(isTextOn == false)
            {
                isTextOn = true;
                TVSoundPlayer.PlayOneShot(CheckOn);
                TVSoundPlayer.loop = false;
                textManager.OtherTextOn(4);
                StartCoroutine("isTextFalse");
            }
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

    IEnumerator isTextFalse()
    {
        yield return new WaitForSeconds(2.5f);
        isTextOn = false;
    }

    public void StopLight()
    {
        TVSoundPlayer.Stop();
        StopCoroutine("ITVLightBlinking");
        transform.GetChild(0).gameObject.SetActive(false);
        isOn = false;
    }
}
