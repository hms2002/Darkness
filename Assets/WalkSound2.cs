using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound2 : MonoBehaviour
{
    private FirstPersonController first;
    public AudioClip walkSound;
    public AudioClip sprintSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        first = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(audioSource.enabled == false)
        {
            return;
        }
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
