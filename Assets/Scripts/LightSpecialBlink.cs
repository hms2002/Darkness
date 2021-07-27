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
    IEnumerator corutine;
    private void Start() {
        lastSpecialDoor = FindObjectOfType<plusLastSpecialDoor>();
        lastSpecialDoor.lightOut2 += StopBlink;
        plusSpecialTrigger = FindObjectOfType<PlusSpecialTrigger>();
        plusSpecialTrigger.specialforstTriggerAction += str;
        door = FindObjectOfType<Door>();
        corutine = Blink();
        if(door.isTriggerStart == false || door.isTriggerStart == true)
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
        StopCoroutine(corutine);
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
