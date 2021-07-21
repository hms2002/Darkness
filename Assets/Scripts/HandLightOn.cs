using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightOn : MonoBehaviour
{
    private AudioSource handLightSoundPlayer;
    public AudioClip handLightSound;
    public SpecialNewspaper specialNewspaper;
    private plusLastSpecialDoor plusLast;

    private void Start() {
        handLightSoundPlayer = GetComponent<AudioSource>();
        specialNewspaper = FindObjectOfType<SpecialNewspaper>();
        plusLast = FindObjectOfType<plusLastSpecialDoor>();
        if(specialNewspaper != null)
        {
            specialNewspaper.lightOut += LightOff;
            specialNewspaper.afterMove += LightOn;
        }
        if(plusLast != null)
        {
            plusLast.lightOut2 += LightOff;
            plusLast.afterMove2 += LightOn;
        }
    }

    public void LightOn()
    {
        StartCoroutine("ILightOn");
    }

    public void LightOff()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        handLightSoundPlayer.PlayOneShot(handLightSound);

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
