using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private GameObject Player;
    private RaycastHit hit;
    public float originVolum = 1f; 
    public float smallVol = 0.2f;
    private void Start() {
        Player = GameObject.Find("Player");
    }

    private void Update() {
        RayCheck();

    }
    public void RayCheck()
    {
        var rayOrigin = transform.position;
        var rayDir = Player.transform.position - gameObject.transform.position;
        Debug.DrawRay(rayOrigin, rayDir * 2, Color.green);
        if(Physics.Raycast(rayOrigin, rayDir, out hit, 100f, (1 << (LayerMask.NameToLayer("Player")) | 1 << (LayerMask.NameToLayer("Buliding"))| 1 << (LayerMask.NameToLayer("IntObj")))))
        {
            if(!(hit.transform.CompareTag("Player")))
            {
                if((0 < Player.transform.position.y - transform.position.y && Player.transform.position.y - transform.position.y < 5) || (-5 < Player.transform.position.y - transform.position.y && Player.transform.position.y - transform.position.y < 0))
                {
                    if(smallVol < GetComponent<AudioSource>().volume)
                    {
                        gameObject.GetComponent<AudioSource>().volume -= smallVol * Time.deltaTime * 0.7f;
                    }
                    else
                    {
                        gameObject.GetComponent<AudioSource>().volume = smallVol;
                    }   //fdsf
                }
                else{
                    gameObject.GetComponent<AudioSource>().volume = smallVol;
                }
            }
            else{
                if(gameObject.GetComponent<AudioSource>().volume <= originVolum)
                {
                    gameObject.GetComponent<AudioSource>().volume += smallVol * Time.deltaTime * 0.7f;
                }
            }
        }//ds

    }
}
/*
다 0.2로 바꾸기
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
        smallVol = 0.2f;
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
            if(!(hit.transform.CompareTag("Player")))
            {
                if((0 < Player.transform.position.y - transform.position.y && Player.transform.position.y - transform.position.y < 5) || (-5 < Player.transform.position.y - transform.position.y && Player.transform.position.y - transform.position.y < 0))
                {
                    if(smallVol < originVolum)
                    {
                        gameObject.GetComponent<AudioSource>().volume -= smallVol * Time.deltaTime * 3f;
                        originVolum = GetComponent<AudioSource>().volume;
                    }
                    else
                    {
                        gameObject.GetComponent<AudioSource>().volume = smallVol;
                        originVolum = GetComponent<AudioSource>().volume;
                    }   //fdsf
                }
                else{
                    gameObject.GetComponent<AudioSource>().volume = 0f;
                }
            }
            else{
                if(gameObject.GetComponent<AudioSource>().volume <= 0.2f)
                {
                    gameObject.GetComponent<AudioSource>().volume += smallVol * Time.deltaTime * 5f;
                    originVolum = GetComponent<AudioSource>().volume;
                }
            }
        }

    }
}
*/
