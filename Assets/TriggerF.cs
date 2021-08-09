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
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            textManager.OtherTextOn(16);
            gameObject.SetActive(false);
        }
    }

    IEnumerator TextStart()
    {
        textManager.OtherTextOn(13);
        yield return new WaitForSeconds(3f);
        textManager.OtherTextOn(14);
        yield return new WaitForSeconds(4f);
        textManager.OtherTextOn(15);
        gameObject.SetActive(false);
    }
}
