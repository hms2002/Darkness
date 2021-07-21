using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpecialBlink : MonoBehaviour
{
    public float minInculsive = 0.05f;
    public float maxInculsive = 0.1f;
    private plusLastSpecialDoor lastSpecialDoor;
    private void Start() {
        StartCoroutine("Blink");
        lastSpecialDoor = FindObjectOfType<plusLastSpecialDoor>();
        lastSpecialDoor.lightOut2 += StopBlink;
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
