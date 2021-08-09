using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUseCam : MonoBehaviour
{
    public GameObject objectLight;
    public GameObject lightBefore;
    public GameObject lightAfter;
    public GameObject One;
    public Camera camPlayer;
    public Camera camEvent;
    private GameManager gameManager;
    private Inventory inv;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        inv = FindObjectOfType<Inventory>();
        inv.useGun += ChangeCam;
    }
    
    public void ChangeCam()
    {
        StartCoroutine("change");
        StartCoroutine("C");
    }

    IEnumerator C()
    {
        yield return new WaitForSeconds(3);
        camEvent.gameObject.GetComponent<Animator>().SetTrigger("animStart");
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(2);
        One.SetActive(true);
        camPlayer.enabled = false;
        camPlayer.transform.parent.gameObject.GetComponent<AudioListener>().enabled = false;
        lightBefore.SetActive(false);
        objectLight.SetActive(false);
        lightAfter.SetActive(true);
        camEvent.enabled = true;
        camEvent.gameObject.GetComponent<AudioListener>().enabled = true;
        inv.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        while(gameManager.enabled == false)
        {
            yield return new WaitForSeconds(0.01f);
        }
        gameManager.enabled = false;
    }
}
