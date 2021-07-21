using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpecialTrigger2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject HandLight;
    void Start()
    {
        HandLight = GameObject.Find("WeponPibot");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
                
            HandLight.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
