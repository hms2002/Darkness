using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SizeCtrl : MonoBehaviour
{
    private RectTransform rect;
    bool once = true;

    private void OnEnable() {
        rect = GetComponent<RectTransform>();
        Fix(0);
    }

    public void Fix(int length)
    {
        if(once)
        {
            StartCoroutine("p");

            once = false;
        }

    }

    IEnumerator p()
    {
        
        for(int i = 0; i < 200; i ++)
        {
            rect.rect.Set(rect.rect.x,rect.rect.y,i, rect.rect.height);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
