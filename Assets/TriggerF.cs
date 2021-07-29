using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerF : MonoBehaviour
{
    private TextManager textManager;
    private HintManager hintManager;
    private void OnTriggerEnter(Collider other) {
        textManager = FindObjectOfType<TextManager>();
        hintManager = FindObjectOfType<HintManager>();
        if(hintManager.cnt == 1)
        {
            StartCoroutine("TextStart");
        }
        else
        {
            textManager.OtherTextOn(16);
        }
    }

    IEnumerator TextStart()
    {
        textManager.OtherTextOn(13);
        yield return new WaitForSeconds(3f);
        textManager.OtherTextOn(14);
        yield return new WaitForSeconds(3f);
        textManager.OtherTextOn(15);
    }
}
