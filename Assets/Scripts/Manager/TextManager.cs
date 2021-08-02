using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    public bool isTextOn = false;
    private Text text;
    public float delay;

    #region ScenarioField
    private string[] doorScenario = {
        "조금 더 둘러보자",
        "열리지 않아. 문을 열 수 있는 방법을 찾아보자",
        "열쇠가 필요해",
        "열쇠는 아마 마네킹이 있는 방의 금고 안에 있을 거야",
        "단서를 더 찾아보자..",
        "열리지 않아..",
        "잠겨있다.",
        "아무래도 이 집에 갇힌 것 같다",//7
        "탈출할 수 있는 방법을 찾아보자",
        "문이 열리지 않아! 이게 무슨 일이지?"
    };

    private string[] stairScenario = 
    {
        "발소리가 들린다, 잠시 밖으로 나가자",
        "일단 밖으로 나가자"
    };

    private string[] mannequinScenario = //fdd
    {
        "쑤셔 넣기",
        "목 조르기",
        "쏴 죽이기"
    };

    private string[] otherScenario = 
    {
        "날이 상해 있다",
        "피비린내가 난다",
        "식탁에 놓기",
        "맛있는 고기다",
        "켜지지 않는다",
        "Click to Move",
        "건전지가 필요해",
        "건전지다",
        "힌트를 먼저 찾자",
        "이상한 그림이다..",
        "힌트를 얻었다",
        "힌트를 다 얻은 것 같다",
        "마네킹이 있던 방으로 돌아가보자",
        "아까 찾은 그림이 보인다.",//13
        "이 집에서 탈출하기 위한 방법인 것 같다.",
        "나머지 힌트도 찾아보자.",
        "탈출하기 위한 힌트를 찾아야 할 것 같다.",
        "힌트대로 행동하면 탈출할 수 있을 것 같다"//17
    };
    #endregion
    private void Start() {
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
    }
    #region StartTextOnField
    public void DoorTextOn(int scriptNum)
    {
        StartCoroutine("IDoorTextOn", scriptNum);
    }
    public void StairTextOn(int scriptNum)
    {
        StartCoroutine("IStairTextOn", scriptNum);
    }
    public void MannequinTextOn(int scriptNum)
    {        
        if(isTextOn == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            text.text = mannequinScenario[scriptNum];
        }
    }
    #region AlwaysOn
    public void MeatSetting()
    {        
        if(isTextOn == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            text.text = otherScenario[2];
        }
    }
    public void Click()
    {        
        if(isTextOn == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            text.text = otherScenario[5];
        }
    }
    public void EUse()
    {
        if(isTextOn == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            text.text = "\'E\' to Use";
        }
    }
    #endregion
    public void OtherTextOn(int scriptNum)
    {
        StartCoroutine("IOtherTextOn", scriptNum);
    }
    public void TextClose()
    {
        if(isTextOn == false)
        transform.GetChild(0).gameObject.SetActive(false);
    }
    #endregion
    #region ITextOnField
    IEnumerator IDoorTextOn(int scriptNum)
    {
        if(isTextOn == false)
        {
            isTextOn = true;
            transform.GetChild(0).gameObject.SetActive(true);  
            for(int i = 0; i < doorScenario[scriptNum].Length; i++)
            {
                text.text = doorScenario[scriptNum].Substring(0, i+1);
                yield return new WaitForSeconds(delay);
            }
            text.text = doorScenario[scriptNum];
            yield return new WaitForSeconds(2f);
            isTextOn = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    IEnumerator IStairTextOn(int scriptNum)
    {
        if(isTextOn == false)
        {
            isTextOn = true;
            transform.GetChild(0).gameObject.SetActive(true);
            for(int i = 0; i < stairScenario[scriptNum].Length; i++)
            {
                text.text = stairScenario[scriptNum].Substring(0, i+1);
                yield return new WaitForSeconds(delay);
            }
            text.text = stairScenario[scriptNum];
            yield return new WaitForSeconds(2f);
            isTextOn = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator IOtherTextOn(int scriptNum)
    {
        if(isTextOn == false)
        {
            isTextOn = true;
            transform.GetChild(0).gameObject.SetActive(true);
            for(int i = 0; i < otherScenario[scriptNum].Length; i++)
            {
                text.text = otherScenario[scriptNum].Substring(0, i+1);
                yield return new WaitForSeconds(delay);
            }
            text.text = otherScenario[scriptNum];
            yield return new WaitForSeconds(2f);
            isTextOn = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    #endregion

}