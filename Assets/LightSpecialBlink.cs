using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpecialBlink : MonoBehaviour
{
    public float minInculsive = 0.05f;
    public float maxInculsive = 0.1f;
    private plusLastSpecialDoor lastSpecialDoor;
    private PlusSpecialTrigger plusSpecialTrigger;
    private Door door;
    private void Start() {
        lastSpecialDoor = FindObjectOfType<plusLastSpecialDoor>();
        lastSpecialDoor.lightOut2 += StopBlink;
        plusSpecialTrigger = FindObjectOfType<PlusSpecialTrigger>();
        plusSpecialTrigger.specialforstTriggerAction += str;
        door = FindObjectOfType<Door>();

        if(door.isTriggerStart == false)
        {
            str();
        }
    }

    public void str()
    {
        StartCoroutine("Blink");
    }

    private void StopBlink()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Blink()
    {
        while(true)
        {
            gameObject.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(Random.Range(minInculsive, maxInculsive));
            gameObject.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(Random.Range(minInculsive, maxInculsive));
        }
    }

}
