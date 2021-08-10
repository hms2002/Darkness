using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound;
    public GameObject ESCCanvas;
    public GameObject MainCanvas;
    private bool isOptionOn = false;

    public void OptionOn()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clickSound);
        isOptionOn = true;
        MainCanvas.SetActive(false);
        ESCCanvas.SetActive(true);
    }

    public void OptionOff()
    {
        audioSource.PlayOneShot(clickSound);
        isOptionOn = false;
        MainCanvas.SetActive(true);
        ESCCanvas.SetActive(false);
    }

}
