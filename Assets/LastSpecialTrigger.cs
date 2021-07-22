using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpecialTrigger : MonoBehaviour
{
    public GameObject Ghost;
    private AudioSource audioSource;
    public AudioClip ZombieOnSound;
    private FirstPersonController firstPersonController;
    private plusLastSpecialDoor lastSpecialDoor;
    public float height;
    private GameObject HandLight;
    private GameObject GhostPobot;
    private bool isOnce = true;
    public float DestTime = 2f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        firstPersonController = FindObjectOfType<FirstPersonController>();
        lastSpecialDoor = FindObjectOfType<plusLastSpecialDoor>();
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
        audioSource.PlayOneShot(ZombieOnSound);
        GameObject inst = Object.Instantiate(Ghost, new Vector3(GhostPobot.transform.position.x,height,GhostPobot.transform.position.z), Quaternion.Euler(-Camera.main.transform.forward));
        firstPersonController.ghostOn = true;
        yield return new WaitForSeconds(DestTime);

        Destroy(inst);
        firstPersonController.ghostOn = false;
        yield return new WaitForSeconds(0.5f);
        lastSpecialDoor.On();
    }
}
