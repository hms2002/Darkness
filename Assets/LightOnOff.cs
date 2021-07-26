using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    private Light light1;
    private lightZ lightS;
    private void Start() {
        light1 = GetComponent<Light>();
        lightS = FindObjectOfType<lightZ>();
        light1.enabled = false;
        lightS.lightOn += On;
    }

    public void On()
    {
        light1.enabled = true;
    }

    
}
