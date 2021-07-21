using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fade");
    }

    public void Shot()
    {
        StartCoroutine("FadeOut");
    } 

    IEnumerator Fade()
    {
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a-0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator FadeOut()
    {
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a+0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(0.005f);
        }
    }


    
}
