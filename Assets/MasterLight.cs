using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MasterLight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Light[] handlight = new Light[2];
    public GameObject pannel;
    public GameObject sliders;
    public Camera camP;
    public Camera camE;
    public Canvas canvas;
    public void ChangeLight(float percentage)
    {
        handlight[0].intensity = percentage;
        handlight[1].intensity = percentage;
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        camP.enabled = true;
        camE.enabled = false;
        
        pannel.SetActive(false);
        sliders.SetActive(false);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        camP.enabled = false;
        camE.enabled = true;
        
        pannel.SetActive(true);
        sliders.SetActive(true);

    }
}
