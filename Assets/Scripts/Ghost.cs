using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public AudioSource screamSoundPlayer;
    public AudioClip screamSound;
    public AudioClip CrySound;
    private Knife knife;
    public bool alreadyDest = false;
    private void Awake() {
        GhostOn();
    }
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        screamSoundPlayer = GetComponent<AudioSource>();
        StartCoroutine("StartFalse");
        knife = FindObjectOfType<Knife>();
        knife.getKnifeEvent += Scream;
    }
    
    public void GhostOn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Scream()
    {
        StartCoroutine("ScreamIEnum");
        if(alreadyDest)
        {
            knife.getKnifeEvent -= Scream;
        }
    }
    public void Cry()
    {
        screamSoundPlayer.PlayOneShot(CrySound);
    }

    IEnumerator ScreamIEnum()
    {
        screamSoundPlayer.PlayOneShot(screamSound);
        yield return new WaitForSeconds(2f);
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(false);

    }
    IEnumerator StartFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
