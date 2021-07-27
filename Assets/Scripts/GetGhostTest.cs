using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGhostTest : MonoBehaviour
{
    public GameObject Ghost;
    private GameObject HandLight;
    private ChangeColorTest changeColor;
    private FirstPersonController firstPersonController;
    private GameObject GhostPobot;

    private void Start() {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        HandLight = GameObject.Find("WeponPibot");
        GhostPobot = GameObject.Find("GhostPivot");
        changeColor = FindObjectOfType<ChangeColorTest>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            StartCoroutine("GetGhost");
        }
    }

    IEnumerator GetGhost()
    {
        changeColor.LightGoRed();
        yield return new WaitForSeconds(10f);
        HandLight.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        HandLight.transform.GetChild(0).gameObject.SetActive(true);
        GameObject inst = Object.Instantiate(Ghost, new Vector3(GhostPobot.transform.position.x,6,GhostPobot.transform.position.z), transform.rotation);
        firstPersonController.ghostOn = true;
        yield return new WaitForSeconds(5f);

        Destroy(inst);
        firstPersonController.ghostOn = false;
        gameObject.SetActive(false);
    }
}
