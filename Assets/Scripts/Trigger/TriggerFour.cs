using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFour : MonoBehaviour
{
    private GameObject ghost;
    private FirstFloorBethRoomDoor first;
    private void Start() {
        ghost = GameObject.Find("Ghost");
        StartCoroutine("StartFalse");
        first = FindObjectOfType<FirstFloorBethRoomDoor>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            first.IsTriggerOn();
            ghost.SetActive(true);
            ghost.GetComponent<Ghost>().Cry();
            gameObject.SetActive(false);
        }
    }
    IEnumerator StartFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    
}
