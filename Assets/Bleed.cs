using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public Animator anim3;

    private AudioSource audio1;
    private AudioSource audio2;
    private AudioSource audio3;

    public AudioClip clipHeart;
    public AudioClip clipDeath;
    public AudioClip clipEnd;

    private FadeManager fadeManager;

    public void BleedStart()
    {
        anim.SetTrigger("Bleed");
    }

    public void Blink()
    {
        anim2.SetTrigger("Up");
        anim3.SetTrigger("Down");
    }

    public void SoundOn()
    {
        audio2 = transform.GetChild(0).transform.gameObject.GetComponent<AudioSource>();
        audio3 = transform.GetChild(1).transform.gameObject.GetComponent<AudioSource>();
        audio1 = gameObject.GetComponent<AudioSource>();

        audio1.volume = 0;
        audio2.volume = 0;
        audio3.volume = 0;
        audio1.loop = true;
        audio2.loop = true;
        audio3.loop = true;
        audio1.clip = clipEnd;
        audio2.clip = clipHeart;
        audio3.clip = clipDeath;
        StartCoroutine("Snd1");
        StartCoroutine("Snd2");

    }

    public void Fade()
    {
        fadeManager = FindObjectOfType<FadeManager>();
        fadeManager.EndFade();
    }


    IEnumerator Snd1()
    {
        audio2.Play();
        while (audio2.volume < 1)
        {
            yield return new WaitForSeconds(0.02f);
            audio2.volume += 0.002f;
        }
        StartCoroutine("Snd3");
    }
    IEnumerator Snd2()
    {
        audio3.Play();
        while (audio3.volume < 1)
        {
            yield return new WaitForSeconds(0.02f);
            audio3.volume += 0.002f;
        }
    }
    IEnumerator Snd3()
    {
        audio1.Play();
        while (audio1.volume < 1)
        {
            yield return new WaitForSeconds(0.01f);
            audio1.volume += 0.04f;
        }
    }
}
