using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpecialTrigger : MonoBehaviour
{
    public GameObject Ghost;
    private FirstPersonController firstPersonController;
    public float height;
    private GameObject HandLight;
    private GameObject GhostPobot;
    private bool isOnce = true;
    public float DestTime = 2f;
    void Start()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        HandLight = GameObject.Find("WeponPibot");
        GhostPobot = GameObject.Find("GhostPivot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && isOnce)
        {
            StartCoroutine("z");
        }
    }

    IEnumerator z()
    {
        isOnce = false;
        HandLight.transform.GetChild(0).gameObject.SetActive(true);
        GameObject inst = Object.Instantiate(Ghost, new Vector3(GhostPobot.transform.position.x,height,GhostPobot.transform.position.z), transform.rotation);
        firstPersonController.ghostOn = true;
        yield return new WaitForSeconds(DestTime);

        Destroy(inst);
        firstPersonController.ghostOn = false;
        gameObject.SetActive(false);
    }
}
