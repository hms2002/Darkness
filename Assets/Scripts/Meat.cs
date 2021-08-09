using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour, IItem
{
    public bool canSet = false;
    public bool canEat = false;
    public bool isOnce = true;
    private TextManager textManager;
    private FadeManager fadeManager;
    private Inventory inventory;
    private GameObject pibot2;
    private RayInteraction rayInteraction;
    private AudioSource audioSource;
    public AudioClip meatEatSound;
    private void Start() {
        textManager = FindObjectOfType<TextManager>();
        inventory = FindObjectOfType<Inventory>();
        rayInteraction = FindObjectOfType<RayInteraction>();
        fadeManager = FindObjectOfType<FadeManager>();
        audioSource = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        inventory.useRope += CanSet;
        pibot2 = GameObject.Find("EatTablePivot");
    }
    public void Interact()
    {
        if(canSet == false)
        {
            textManager.OtherTextOn(1);
        }
        else if(canSet && canEat == false){
            rayInteraction.eatDesk = true;
            transform.parent.gameObject.SetActive(false);
        }
        else if(canSet &&canEat && isOnce)
        {
            gameObject.layer = 0;
            fadeManager.FadeWepon();
            audioSource.PlayOneShot(meatEatSound); 
            StartCoroutine("ISetActice");
            isOnce = false;
        }
    }
    public void CanSet()
    {
        canSet = true;
    }
    IEnumerator ISetActice()
    {
        yield return new WaitForSeconds(2.5f);
        pibot2.transform.GetChild(0).gameObject.SetActive(true);
        transform.parent.GetChild(1).gameObject.SetActive(false);
        textManager.OtherTextOn(3);
        rayInteraction.eatDesk = false;
        audioSource.Stop();
    }
}
