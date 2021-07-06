using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private GameObject Player;
    private RaycastHit hit;
    private float originVolum; 
    private float smallVol;
    private void Start() {
        Player = GameObject.Find("Player");
        originVolum = GetComponent<AudioSource>().volume;
        smallVol = 0.3f;
    }

    private void Update() {
        RayCheck();

    }
    public void RayCheck()
    {
        var rayOrigin = transform.position;
        var rayDir = Player.transform.position - gameObject.transform.position;
        Debug.DrawRay(rayOrigin, rayDir * 2, Color.green);
        if(Physics.Raycast(rayOrigin, rayDir, out hit, 100f, (1 << (LayerMask.NameToLayer("Player")) | 1 << (LayerMask.NameToLayer("Buliding")))))
        {
            Debug.Log(hit.transform.gameObject.tag);
            if(!(hit.transform.CompareTag("Player")))
            {
                gameObject.GetComponent<AudioSource>().volume = smallVol;
            }
            else{
                gameObject.GetComponent<AudioSource>().volume = 1f;
            }
        }

    }
}
