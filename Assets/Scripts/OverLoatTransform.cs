using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OverLoatTransform : MonoBehaviour
{
    public Camera mainCam;
    GameObject gmoPlayer;
    void Awake()
    {
        gmoPlayer = GameObject.Find("InSimpleSceneFirstPerson2");
        this.gameObject.transform.position = gmoPlayer.transform.position;
        this.gameObject.transform.rotation = gmoPlayer.transform.rotation;
        
        gmoPlayer.gameObject.SetActive(false);
        mainCam.enabled = true;
    }


}
