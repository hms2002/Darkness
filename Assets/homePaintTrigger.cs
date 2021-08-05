using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homePaintTrigger : MonoBehaviour
{
    public GameObject Game;
    private AudioSource audioSource;
    public AudioClip paintSound;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {

            Game.SetActive(true);
            audioSource.PlayOneShot(paintSound);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
