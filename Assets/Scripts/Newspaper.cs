using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Newspaper : MonoBehaviour, IItem
{
    public Image newspapper;
    public Text conversationText;
    public Text ScriptText;
    public Text NewsDownText;
    private FadeManager fadeManager;
    private SceneGameManager sceneGameManager;
    private GameObject Player;
    private GameObject blawScreen;
    private GameObject Panel;
    public bool letGoNextScene = false;
    private int cnt = 0;


    private void Start() {
        fadeManager = FindObjectOfType<FadeManager>();
        sceneGameManager = FindObjectOfType<SceneGameManager>();
        blawScreen = GameObject.Find("BlawScreenPibot");
        Player = GameObject.Find("Player");
        Panel = blawScreen.transform.GetChild(0).gameObject;
        //InSimpleSceneFirstPerson 
    }

    private void Update() {
        if(letGoNextScene)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {        
            cnt++;
                switch(cnt)
                {
                    case 1:
                        ScriptText.gameObject.SetActive(false);
                        conversationText.gameObject.SetActive(false);
                        blawScreen.transform.GetChild(0).gameObject.SetActive(false);
                        Player.GetComponent<FirstPersonController>().enabled = true;
                        NewsDownText.gameObject.SetActive(true);
                        StartCoroutine("IT");
                    break;
                }
            }
        }   
    }

    public void Interact()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        blawScreen.transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        conversationText.text = "<space>";
        letGoNextScene = true;
        Panel.transform.GetChild(2).gameObject.SetActive(true);
        ScriptText.text = "최근 벌어진 연쇄 살인 사건의 용의자가 살고 있었던 것으로 추정되는 집에 귀신이 나온다는 소문이 확산되고 있다...";
                   
    }
    IEnumerator GoSceneLater()
    {
        yield return new WaitForSeconds(1.5f);
        sceneGameManager.GoScene3();
    }
    IEnumerator IT()
    {
        NewsDownText.text = "...";
        yield return new WaitForSeconds(2);
        NewsDownText.text = "가볼까?";
        yield return new WaitForSeconds(2);
        newspapper.gameObject.SetActive(false);
        NewsDownText.text = "";
        fadeManager.FadeIn();
        StartCoroutine("GoSceneLater");
    }
}
