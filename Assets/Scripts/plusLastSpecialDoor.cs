using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class plusLastSpecialDoor : MonoBehaviour
{
    public Action lightOut2;
    public Action goAnotherWorld2;
    public Action afterMove2;
    private MainGameSound mainGameSound;

    public void On() 
    {    
        StartCoroutine("GoBackHouse");
        mainGameSound = FindObjectOfType<MainGameSound>();
    }

    IEnumerator GoBackHouse()
    {
        lightOut2();
        yield return new WaitForSeconds(1);
        goAnotherWorld2();
        yield return new WaitForSeconds(1);
        afterMove2();
        mainGameSound.StartCoroutine("VolumeUp");
        gameObject.SetActive(false);
    }
}
