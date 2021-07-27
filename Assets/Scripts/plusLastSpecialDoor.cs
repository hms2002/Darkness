using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class plusLastSpecialDoor : MonoBehaviour
{
    public Action lightOut2;
    public Action goAnotherWorld2;
    public Action afterMove2;

    public void On() 
    {    
            StartCoroutine("GoBackHouse");
    }

    IEnumerator GoBackHouse()
    {
        lightOut2();
        yield return new WaitForSeconds(1);
        goAnotherWorld2();
        yield return new WaitForSeconds(1);
        afterMove2();
        gameObject.SetActive(false);
    }
}
