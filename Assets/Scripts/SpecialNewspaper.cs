using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpecialNewspaper : MonoBehaviour, IItem
{
    public Action lightOut;
    public Action goAnotherWorld;
    public Action afterMove;
    private bool afterUseRope = false;
    private Inventory inventory;
    private void Start() {
        inventory = FindObjectOfType<Inventory>();
        inventory.useRope += UseRope;
    }

    public void Interact()
    {
        if(afterUseRope)
        {
            StartCoroutine("Light_Move");
        }
    }

    public void UseRope()
    {
        afterUseRope = true;
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
