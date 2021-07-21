using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSpecialTrigger : MonoBehaviour
{
    public PlusSpecialDoor plusSpecialDoor;
    void Start()
    {        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            plusSpecialDoor.AlreadyMove();
            gameObject.SetActive(false);
        }
    }
}
