using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRotationColtrol : MonoBehaviour
{
    private GameObject player;
    private void Awake() {
        player = GameObject.FindWithTag("Player");
        Vector3 dir = player.transform.position - transform.position;
        Debug.Log(dir);
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0,dir.z));
        // Quaternion s = transform.rotation;
        // s.x = 0;
        // s.y = 0;
        // transform.rotation = s;
    }
}
