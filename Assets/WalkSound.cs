using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip sprintSound;
    public AudioClip walkSoundGround;
    public AudioClip sprintSoundGround;
    public AudioClip walkSoundStair;
    public AudioClip sprintSoundStair;
    private FirstPersonController first;
    public bool inBuilding = false;
    public bool inGround = true;
    public bool inStair = false;
    private void Start() {
        first = FindObjectOfType<FirstPersonController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate() {
        if(audioSource.enabled == false)
        {
            return;
        }
        if(inBuilding)
        {
            audioSource.volume = 0.8f;
            if(first.isSprinting && first.isWalking)
            {
                if(audioSource.clip != sprintSound)
                {
                    audioSource.Stop();
                }
                audioSource.clip = sprintSound;
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
            else if(first.isWalking)
            {
                if(audioSource.clip != walkSound)
                {
                    audioSource.Stop();
                }
                audioSource.clip = walkSound;
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
            else{
                StartCoroutine("Vol");
            }
        }
        else if(inGround)
        {
            audioSource.volume = 0.2f;
            if(first.isSprinting && first.isWalking)
            {
                if(audioSource.clip != sprintSoundGround)
                {
                    audioSource.Stop();
                }
                audioSource.clip = sprintSoundGround;
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
            else if(first.isWalking)
            {
                if(audioSource.clip != walkSoundGround)
                {
                    audioSource.Stop();
                }
                audioSource.clip = walkSoundGround;
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
            else{
                StartCoroutine("Vol");
            }
        }
        else if(inStair)
        {
            audioSource.volume = 0.7f;
            if(first.isSprinting && first.isWalking)
            {
                if(audioSource.clip != sprintSoundStair)
                {
                    audioSource.Stop();
                }
                audioSource.clip = sprintSoundStair;
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
            else if(first.isWalking)
            {
                if(audioSource.clip != walkSoundStair)
                {
                    audioSource.Stop();
                }
                audioSource.clip = walkSoundStair;
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
            else{
                StartCoroutine("Vol");
            }
        }
    }
    
    IEnumerator Vol()
    {
        while(audioSource.volume != 0)
        {
            audioSource.volume -= 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
        if(audioSource.isPlaying == false)
        audioSource.Stop();
    }
    

}
