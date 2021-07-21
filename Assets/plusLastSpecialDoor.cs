using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class plusLastSpecialDoor : MonoBehaviour
{
    public Action lightOut2;
    public Action goAnotherWorld2;
    public Action afterMove2;

    private void OnTriggerEnter(Collider other) 
    {    
        if(other.CompareTag("Player"))
        {
            StartCoroutine("GoBackHouse");
        }
    }

    IEnumerator GoBackHouse()
    {
        lightOut2();
        yield return new WaitForSeconds(1);
        goAnotherWorld2();
        yield return new WaitForSeconds(1);
        afterMove2();
    }
}
