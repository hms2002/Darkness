using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouse : MonoBehaviour
{
    public int index = 0;
    private WalkSound walkSound;

    private void Start() {
        walkSound = FindObjectOfType<WalkSound>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            switch(index)
            {
                case 0:
                    walkSound.inBuilding = false;
                    walkSound.inGround = true;
                    walkSound.inStair = false;
                break;
                case 1:
                    walkSound.inBuilding = true;
                    walkSound.inGround = false;
                    walkSound.inStair = false;
                break;
                case 2:
                    walkSound.inBuilding = false;
                    walkSound.inGround = false;
                    walkSound.inStair = true;
                    Debug.Log("inStair");
                break;
            }
        }
    }
}
