using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageMoveTestScript : MonoBehaviour
{
    public GameObject gmo;
    void Awake()
    {
        StartCoroutine("newsUp");
    }

    public void NewsDown()
    {
        StartCoroutine("INewsDown");
    }

    IEnumerator newsUp()
    {
        float y = gmo.GetComponent<RectTransform>().anchoredPosition.y;
        for(int i = 0; i < 100; i++)
        {
            y += 4.5f;
            gmo.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y);

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator INewsDown()
    {
        float y = gmo.GetComponent<RectTransform>().anchoredPosition.y;
        for(int i = 0; i < 100; i++)
        {
            y -= 4.5f;
            gmo.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y);

            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
    }

    
}
