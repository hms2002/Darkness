using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FadeManager : MonoBehaviour
{
    private Animator CreditAnim;
    GameManager game;
    private SceneGameManager sceneGameManager;
    private GameObject fadeImageParent;
    private ClickSound clickSound;
    public Action SceneMoveAction;
    private Inventory inventory;
    private Image fadeImage;
    public float fadeInSpeed = 0.001f;//
    public float fadeOutSpeed = 0.01f;
    private void Start() {
        game = FindObjectOfType<GameManager>();
        sceneGameManager = FindObjectOfType<SceneGameManager>();
        fadeImageParent = GameObject.Find("FadeImageParent");
        fadeImage = fadeImageParent.transform.GetChild(0).gameObject.GetComponent<Image>();
        inventory  = FindObjectOfType<Inventory>();
        inventory.useKnife += FadeWepon;
        inventory.useRope += FadeWepon;
        inventory.useGun += FadeWepon;
        //Cursor.lockState = CursorLockMode.Locked
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

    public void FadeAndMoveScene()
    {
        clickSound = FindObjectOfType<ClickSound>();
        StartCoroutine("IFadeAndMoveScene");
    }

    public void EndFade()
    {
        StartCoroutine("IEndFade");
    }

    IEnumerator IEndFade()
    {
        yield return new WaitForSeconds(0.5f);
        FadeIn();
        yield return new WaitForSeconds(1);
        Text done = fadeImage.transform.GetChild(0).GetComponent<Text>();
        CreditAnim = done.gameObject.GetComponent<Animator>();
        Color startColor = done.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.r = startColor.r+0.01f;
            startColor.a = startColor.a+0.01f;
            done.color =  startColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        yield return new WaitForSeconds(3f);
        CreditAnim.SetTrigger("CreditOn");
        yield return new WaitForSeconds(1f);
        sceneGameManager.StartCoroutine("fd");

    }
    IEnumerator IFadeAndMoveScene()
    {        
        clickSound.PlaySound();
        fadeImageParent.transform.GetChild(0).gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a+0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        SceneMoveAction();
    }

    IEnumerator IFadeWepon()
    {
        game.enabled = false;
        StartCoroutine("IFadeIn");
        yield return new WaitForSeconds(3);
        StartCoroutine("IFadeOut");
        game.enabled = true;
    }

    IEnumerator IFadeIn()
    {
        fadeImageParent.transform.GetChild(0).gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 50; i++)
        {
            startColor.a = startColor.a+0.02f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }

    }
//fd
    IEnumerator IFadeOut()
    {
        fadeImageParent.transform.GetChild(0).gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a-0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(fadeOutSpeed);
        }
        fadeImageParent.transform.GetChild(0).gameObject.SetActive(false);
    }
}
