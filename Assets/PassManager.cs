using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PassManager : MonoBehaviour
{
    public SafeUIManager safeUIManager;
    GameObject button1;
    GameObject button2;
    GameObject button3;
    GameObject button4;
    public int[] pass = new int[4];
    int cnt = 0;
    private void Awake() {
        safeUIManager = FindObjectOfType<SafeUIManager>();
    }
    void Start()
    {
        button1 = transform.GetChild(0).gameObject;
        button2 = transform.GetChild(1).gameObject;
        button3 = transform.GetChild(2).gameObject;
        button4 = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPass(int num)
    {
        switch(cnt)
        {
            case 0:
            button1.GetComponent<Image>().color = Color.green;
            pass[cnt] = num;
            cnt++;
            break;
            case 1:
            button2.GetComponent<Image>().color = Color.green;
            pass[cnt] = num;
            cnt++;
            break;
            case 2:
            button3.GetComponent<Image>().color = Color.green;
            pass[cnt] = num;
            cnt++;
            break;
            case 3:
            button4.GetComponent<Image>().color = Color.green;
            pass[cnt] = num;
            cnt++;
            break;
        }
    }

    public void SubPass()
    {
        switch(cnt)
        {
            case 1:
            button1.GetComponent<Image>().color = Color.white;
            pass[cnt-1] = -1;
            cnt--;
            break;
            case 2:
            button2.GetComponent<Image>().color = Color.white;
            pass[cnt-1] = -1;
            cnt--;
            break;
            case 3:
            button3.GetComponent<Image>().color = Color.white;
            pass[cnt-1] = -1;
            cnt--;
            break;
            case 4:
            button4.GetComponent<Image>().color = Color.white;
            pass[cnt-1] = -1;
            cnt--;
            break;
        }
    }

    public void Reseting()
    {
        for(int i = 0; i < 4; i++)
            pass[i] = -1;
        button1.GetComponent<Image>().color = Color.white;
        button2.GetComponent<Image>().color = Color.white;
        button3.GetComponent<Image>().color = Color.white;
        button4.GetComponent<Image>().color = Color.white;
        cnt = 0;
    }

    public void CheckPass()
    {
        if(pass[0] == 1 && pass[1] == 2 && pass[2] == 3 && pass[3] == 4)
        {
            Debug.Log("DDD!!!!!");
            safeUIManager.Open();
        }
        else{
            Debug.Log("AAAAAAA!!!!");
        }
    }
}
