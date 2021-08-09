using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Newspaper : MonoBehaviour, IItem
{
    private AudioSource audioSource;
    public AudioClip goSound;
    public AudioClip newsSound;
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
    private string[] senario = {
        "귀신이 나온다고?",
        "...",
        "한번 가보자."
    };


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
                        ScriptText.text = "그는 총 세 명을 살해했으며, 첫 살해는 칼로 피해자의 복부를 여러 차례 찔렀으며 두 번째 살해는 피해자의 목을 밧줄로 감싸 질식하게 했다. 세 번째 살인은 불법 수입한 총기로 피해자의 머리를 쏜 것으로 알려졌다.";
                    break;
                    case 2:
                        ScriptText.gameObject.SetActive(false);
                        conversationText.gameObject.SetActive(false);
                        blawScreen.transform.GetChild(0).gameObject.SetActive(false);
                        Player.GetComponent<FirstPersonController>().enabled = true;
                        NewsDownText.transform.parent.gameObject.SetActive(true);
                        StartCoroutine("IT");
                    break;
                }
            }
        }   
    }

    public void Interact()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(newsSound);
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
        audioSource.PlayOneShot(goSound);
        yield return new WaitForSeconds(22f);
        sceneGameManager.GoScene3();
    }
    IEnumerator IT()
    {
        for(int j = 0; j < 3; j++)
        {
            for(int i = 0; i < senario[j].Length; i++)
            {
                NewsDownText.text = senario[j].Substring(0, i+1);
                yield return new WaitForSeconds(0.04f);
            }
            NewsDownText.text = senario[j];
            yield return new WaitForSeconds(2f);
        }
        newspapper.gameObject.SetActive(false);
        NewsDownText.text = "";
        fadeManager.FadeIn();
        StartCoroutine("GoSceneLater");
    }
}
