using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDoorLittleOpen : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip OpenClip;
    private SafeUIManager safeUIManager;
    public float rotation = -7;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        safeUIManager = FindObjectOfType<SafeUIManager>();
    }

    public void Rotation()
    {
        StartCoroutine("IRotate");
    }

    IEnumerator IRotate()
    {
        audioSource.PlayOneShot(OpenClip);
        for(int i = 0; i < 10; i++)
        {
            transform.Rotate(0,rotation/10, 0);
            yield return new WaitForSeconds(0.01f);
        }
        safeUIManager.isOpen = true;
    }


}
