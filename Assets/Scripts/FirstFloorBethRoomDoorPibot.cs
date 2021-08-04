using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorBethRoomDoorPibot : MonoBehaviour, IItem
{
    private FirstFloorBethRoomDoor firstFloorBethRoomDoor;
    public float Rotate = 11f;
    private float rot;
    public bool isAfterOpen = false;
    private void Start() {
        firstFloorBethRoomDoor = transform.GetChild(0).gameObject.GetComponent<FirstFloorBethRoomDoor>();
    }

    public void Interact()
    {
        if(isAfterOpen)
        {
            isAfterOpen = false;    
            rot = 72 - Rotate;
            StartCoroutine("Third");
                
        }
    }

    IEnumerator Thi()
    {
        for(int i = 0; i < 60; i++)
        {
            transform.Rotate(new Vector3(0, Rotate/60, 0));

            yield return new WaitForSeconds(0.01f); 
        }
        isAfterOpen = true;
        firstFloorBethRoomDoor.isLittelOpen = true;
    }
    IEnumerator Third()
    {
        for(int i = 0; i < 60; i++)
        {
            transform.Rotate(new Vector3(0, rot/60, 0));

            yield return new WaitForSeconds(0.01f); 
        }
    }
}
