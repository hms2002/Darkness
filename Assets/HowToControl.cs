using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowToControl : MonoBehaviour
{
    private FadeManager fadeManager;
    private AudioSource audioSource;
    public AudioClip startSound;
    private Text text;
    private void OnEnable() {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot(startSound);
        fadeManager = FindObjectOfType<FadeManager>();
        text = transform.GetChild(1).gameObject.GetComponent<Text>();
        StartCoroutine("FiveCount");
    }

    IEnumerator FiveCount()
    {
        for(int i = 5; i > 0; i--)
        {
            text.text = "NEXT... " + i;
            yield return new WaitForSeconds(1f);
        }
        fadeManager.FadeAndMoveScene();
    }


}
