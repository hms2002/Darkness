using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpecialNewspaper : MonoBehaviour, IItem
{

    private MainGameSound mainGameSound;
    public Action lightOut;
    public Action goAnotherWorld;
    public Action afterMove;
    public bool afterUseRope = false;
    private Inventory inventory;
    private void Start() {
        inventory = FindObjectOfType<Inventory>();
        mainGameSound = FindObjectOfType<MainGameSound>();
    }

    public void Interact()
    {
        Debug.Log(afterUseRope);
        if(afterUseRope)
        {
            mainGameSound.StartCoroutine("VolumeMute");
            StartCoroutine("Light_Move");
            gameObject.layer = 6;
        }
    }

    IEnumerator Light_Move()
    {
        lightOut();
        yield return new WaitForSeconds(1);
        goAnotherWorld();
        yield return new WaitForSeconds(1);
        afterMove();
        this.enabled = false;
    }
}
