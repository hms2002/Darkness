using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private GameObject fadeImageParent;
    private Inventory inventory;
    private Image fadeImage;
    private void Start() {
        fadeImageParent = GameObject.Find("FadeImageParent");
        fadeImage = fadeImageParent.transform.GetChild(0).gameObject.GetComponent<Image>();
        inventory  = FindObjectOfType<Inventory>();
        inventory.useKnife += FadeWepon;
        inventory.useRope += FadeWepon;
        inventory.useGun += FadeWepon;
    }

    public void FadeIn()
    {
        StartCoroutine("IFadeIn");
    }
    public void FadeWepon()
    {
        StartCoroutine("IFadeWepon");
    }
    public void FadeOut()
    {
        StartCoroutine("IFadeOut");
    }
    IEnumerator IFadeWepon()
    {
        StartCoroutine("IFadeIn");
        yield return new WaitForSeconds(3);
        StartCoroutine("IFadeOut");
    }

    IEnumerator IFadeIn()
    {
        fadeImageParent.transform.GetChild(0).gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a+0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator IFadeOut()
    {
        fadeImageParent.transform.GetChild(0).gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a-0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
