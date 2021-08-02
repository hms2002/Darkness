using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject ESCCanvas;
    public GameObject MainCanvas;
    private bool isOptionOn = false;

    public void OptionOn()
    {
        isOptionOn = true;
        MainCanvas.SetActive(false);
        ESCCanvas.SetActive(true);
    }

    public void OptionOff()
    {
        isOptionOn = false;
        MainCanvas.SetActive(true);
        ESCCanvas.SetActive(false);
    }

}
