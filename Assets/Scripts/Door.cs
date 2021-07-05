using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IItem
{
    public float Rotate = 90/60f;
    bool isOpen = false;
    bool ismove = false;
    private AudioSource doorSoundPlayer;
    public AudioClip openSound;
    public AudioClip closeSound;


    private void Start() {
        doorSoundPlayer = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        StartCoroutine("Thi");
    }

    IEnumerator Thi()
    {
        if(ismove == false)
        {
            if(isOpen == false)
            {
                doorSoundPlayer.PlayOneShot(openSound);
                ismove = true;
                for(int i = 0; i < 60; i++)
                {
                    transform.Rotate(new Vector3(0, Rotate, 0));

                    yield return new WaitForSeconds(0.01f); 
                }
                ismove = false;
                isOpen = true;
            }
            else
            {
                doorSoundPlayer.PlayOneShot(closeSound);
                ismove = true;
                for(int i = 0; i < 60; i++)
                {
                    transform.Rotate(new Vector3(0, -Rotate, 0));

                    yield return new WaitForSeconds(0.01f); 
                }
                ismove = false;
                isOpen = false;
            }
        }
    }
}
