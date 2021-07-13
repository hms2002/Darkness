using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGhostTest : MonoBehaviour
{
    public GameObject Ghost;
    private FirstPersonController firstPersonController;

    private void Start() {
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            StartCoroutine("GetGhost");
        }
    }

    IEnumerator GetGhost()
    {
        Ghost.SetActive(true);
        firstPersonController.ghostOn = true;
        yield return new WaitForSeconds(5f);

        Ghost.SetActive(false);
        firstPersonController.ghostOn = false;
        gameObject.SetActive(false);
    }
}
