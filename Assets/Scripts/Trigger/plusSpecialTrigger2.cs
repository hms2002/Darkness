using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusSpecialTrigger2 : MonoBehaviour
{
    private PlusSpecialDoor plusSpecialDoor;
    void Start()
    {        
        plusSpecialDoor = GameObject.Find("SpecialNewspaperDoorPibot (2)").GetComponent<PlusSpecialDoor>();

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            plusSpecialDoor.AlreadyMove();
            gameObject.SetActive(false);
        }
    }
}
