using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightOn : MonoBehaviour
{
    private AudioSource handLightSoundPlayer;
    public AudioClip handLightSound;
    private void Start() {
        handLightSoundPlayer = GetComponent<AudioSource>();
    }

    public void LightOn()
    {
        StartCoroutine("ILightOn");
    }

    IEnumerator ILightOn()
    {
        yield return new WaitForSeconds(3);
        for(int i = 0; i < 2; i++)
        {
            handLightSoundPlayer.PlayOneShot(handLightSound);
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).gameObject.SetActive(true);
        handLightSoundPlayer.PlayOneShot(handLightSound);
    }
}
