using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpecialNewspaper : MonoBehaviour, IItem
{
    public Action lightOut;
    public Action goAnotherWorld;
    public Action afterMove;
    public void Interact()
    {
        StartCoroutine("Light_Move");
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
