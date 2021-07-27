using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpecialTrigger3 : MonoBehaviour
{
    private GameObject weponePibot;
    private ChangeColorTest changeColor;
    // Start is called before the first frame update
    void Start()
    {
        weponePibot = GameObject.Find("WeponPibot");
        changeColor =  weponePibot.transform.GetChild(0).gameObject.GetComponent<ChangeColorTest>();
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
                
            changeColor.LightGoRed();
        }
    }
}
