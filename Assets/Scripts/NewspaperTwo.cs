using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewspaperTwo : MonoBehaviour, IItem
{
    private AudioSource audioSource;
    public AudioClip newspaperSound;
    private GameObject triggerFive;
    private GameObject Player;
    private GameObject Newspaper;
    private Inventory inventory;
    public Text text;
    private bool isUseKnife = false;
    private bool newsOn = false;
    private bool isOnce = true;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        inventory = FindObjectOfType<Inventory>();
        Player = GameObject.Find("Player");
        triggerFive = GameObject.Find("TriggerFive");
        Newspaper = GameObject.Find("1FnewspaperPibot");
        inventory.useKnife += UseKnife;
    }
    private void Update() {
        if(newsOn)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<FirstPersonController>().enabled = true;
                Player.GetComponent<RayInteraction>().enabled = true;
                Newspaper.transform.GetChild(0).gameObject.SetActive(false);
                newsOn = false;

            }
        }
    }

    public void Interact()
    {
        audioSource.PlayOneShot(newspaperSound);
        StartCoroutine("Control");
        if(isUseKnife && isOnce)
        {        
            triggerFive.SetActive(true);
            isOnce = false;
        }
    }

    public void UseKnife()
    {
        isUseKnife = true;
    }

    IEnumerator Control()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        Player.GetComponent<RayInteraction>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Newspaper.transform.GetChild(0).gameObject.SetActive(true);
        if(isUseKnife)
        {
            text.text = "지난 " + "<color=#ff0000>" + "XX" + "</color>" + "년" + "<color=#ff0000>" + "00" + "</color>" + "월" + "<color=#ff0000>" + "00" + "</color>" + "일 한 하천 인근에서 밧줄에 목이 졸려 죽은 시체가 발견되었다. 시체에서 별다른 저항의 흔적이 발견되지 않아 자살로 판명이 났던 이 사건은 사건 현장에서 반지가 발견되어 재수사에 들어갔다. 조사 결과 반지는 피해자의 것이 아니었으며 인근을 지나갔던 행인들의 것도 아니었기에 반지의 주인이 유력 용의자인 것으로 예상된다.";
        }
        else{
            text.text = "지난 XX년 00월00일 한 하천 인근에서 밧줄에 목이 졸려 죽은 시체가 발견되었다. 시체에서 별다른 저항의 흔적이 발견되지 않아 자살로 판명이 났던 이 사건은 사건 현장에서 반지가 발견되어 재수사에 들어갔다. 조사 결과 반지는 피해자의 것이 아니었으며 인근을 지나갔던 행인들의 것도 아니었기에 반지의 주인이 유력 용의자인 것으로 예상된다.";
        }
        yield return new WaitForSeconds(0.5f);
        newsOn = true;
    }
}
