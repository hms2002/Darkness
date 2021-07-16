using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFive : MonoBehaviour
{
    private GameObject lightPivot4;
    private HandLightOn HandLight;
    void Start()
    {
        StartCoroutine("StartFalse");
        lightPivot4 = GameObject.Find("LightPivot4");
        HandLight = FindObjectOfType<HandLightOn>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            StartCoroutine("IGhostTwoOn");
        }
    }
    IEnumerator StartFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    IEnumerator IGhostTwoOn()
    {
        HandLight.LightOff();
        HandLight.LightOn();
        lightPivot4.transform.GetChild(0).gameObject.SetActive(true);
        lightPivot4.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        lightPivot4.transform.GetChild(0).gameObject.SetActive(false);
        lightPivot4.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
