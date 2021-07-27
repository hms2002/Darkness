using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVQuadSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ZZSOUND;
    public GameObject triggerCCTV;


    private void Awake() {
        triggerCCTV.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ZZSOUND;
        audioSource.loop = true;
        audioSource.Play();
    }



}
