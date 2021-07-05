using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Newspaper : MonoBehaviour, IItem
{
    public Image newspapper;
    public Text conversationText;
    public bool letGoNextScene = false;
    public UnityEvent goNextScene;


    private void Update() {
        StartCoroutine("GoGo");
    }

    public void Interact()
    {
        newspapper.gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        conversationText.text = "재밌겠는데? 가볼까..?" + "\n" + "\'Space\' to go House";
        letGoNextScene = true;
    }

    IEnumerator GoGo()
    {
        yield return new WaitForSeconds(0.5f);
        if(letGoNextScene)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                newspapper.gameObject.SetActive(false);

                goNextScene.Invoke();
            }
        }   
    }
}
