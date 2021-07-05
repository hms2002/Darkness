using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Image fadeImage;

    public void GameStart()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a+0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene("InPlayerHouse");
    }
    
}
