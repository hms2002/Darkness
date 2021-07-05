using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    private AudioSource lightSoundPlayer;
    public AudioClip lightUp;
    public AudioClip lightDown;
    private TriggerTwo triggerTwo;
    private void Start() {
        lightSoundPlayer = GetComponent<AudioSource>();
        triggerTwo = FindObjectOfType<TriggerTwo>();
        triggerTwo.trigger2 += this.Blinking;
    }
    public void Blinking()
    {
        StartCoroutine("Blink");
        StartCoroutine("BlinkStop");
    }
    IEnumerator BlinkStop()
    {
        yield return new WaitForSeconds(10f);
        transform.GetChild(0).gameObject.SetActive(false);

        StopCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while(true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            lightSoundPlayer.PlayOneShot(lightDown);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            lightSoundPlayer.PlayOneShot(lightUp);
        }
    }
}