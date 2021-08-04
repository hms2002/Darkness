using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IItem
{
    public float moveDistance = -2.73f;
    bool isopen = false;
    bool ismove = false;
    private AudioSource audioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    public int index = 1;

    private void Start() {
        if(transform.GetChild(index).gameObject.GetComponent<AudioSource>() != null)
        {
            audioSource = transform.GetChild(index).gameObject.GetComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    public void Interact()
    {
        if(isopen == false && ismove == false)
        {
            StartCoroutine("OpenInteract");
        }
        else if(isopen == true && ismove == false)
        {
            StartCoroutine("CloseInteract");
        }
    }

    IEnumerator OpenInteract()
    {
        ismove = true;
        audioSource.PlayOneShot(doorOpenSound);
        for(int i = 0; i < 60; i++)
        {
            transform.Translate(0,0,moveDistance/60);
            yield return new WaitForSeconds(0.01f);
        }
        isopen = true;
        ismove = false;
    }

    IEnumerator CloseInteract()
    {
        ismove = true;
        audioSource.PlayOneShot(doorCloseSound);
        for(int i = 0; i < 60; i++)
        {
            transform.Translate(0,0,-moveDistance/60);
            yield return new WaitForSeconds(0.01f);
        }
        isopen = false;
        ismove = false;
    }
}
