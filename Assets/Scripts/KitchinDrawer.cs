using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchinDrawer : MonoBehaviour, IItem
{
    public float moveDegree = -80f;
    bool isOpen = false;
    bool isMove = false;
    private AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if(isOpen == false && isMove == false)
        {
            StartCoroutine("OpenInteract");
        }
        else if(isOpen == true&& isMove == false)
        {
            StartCoroutine("CloseInteract");
        }
    }

    IEnumerator OpenInteract()
    {
        isMove = true;
        for(int i = 0; i < 60; i++)
        {
            transform.Rotate(moveDegree/60,0,0);
            yield return new WaitForSeconds(0.01f);
        }
        isOpen = true;
        isMove = false;
    }

    IEnumerator CloseInteract()
    {
        isMove = true;
        for(int i = 0; i < 60; i++)
        {
            transform.Rotate(-moveDegree/60,0,0);
            yield return new WaitForSeconds(0.01f);
        }
        isOpen = false;
        isMove = false;
    }
}
