using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundPlay : MonoBehaviour
{
    private AudioSource triggerSoundPlayer;
    public AudioClip triggerSoundClip;
    private triggerOne triggerDelegate;
    void Start()
    {
        triggerSoundPlayer = GetComponent<AudioSource>();
        triggerDelegate = FindObjectOfType<triggerOne>();
        triggerDelegate.TriggerOne += PlayTriggerSound;
    }

    public void PlayTriggerSound()
    {
        triggerSoundPlayer.PlayOneShot(triggerSoundClip);
    }
    

}
