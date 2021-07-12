using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecialTwo : MonoBehaviour
{
    public DoorSpecialNewspaper doorSpecialNewspaper;
    void Start()
    {
        doorSpecialNewspaper = FindObjectOfType<DoorSpecialNewspaper>();
        StartCoroutine("StartOff");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            doorSpecialNewspaper.OnceOpenOff();
            gameObject.SetActive(false);
        }
    }

    IEnumerator StartOff()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
