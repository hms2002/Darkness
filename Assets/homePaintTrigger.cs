using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homePaintTrigger : MonoBehaviour
{
    public GameObject Game;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Game.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
