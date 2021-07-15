using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip rain;
    public float SoundMaxVol = 0.95f;
    public float SoundSmallVol = 0.4f;
    public float UpSpeed = 0.005f;
    public float DownSpeed = 0.01f;
    private GameObject Player;
    private RaycastHit hit;
    private float originVolum; 
    private float smallVol;
    private BGM bGM2;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
        audioSource.clip = rain;
        gameObject.GetComponent<SoundControl>().enabled = false;
        Player = GameObject.Find("Player");
        originVolum = GetComponent<AudioSource>().volume;
        smallVol = 0.3f;
        bGM2 = GameObject.Find("BGM2").GetComponent<BGM>();
    }
    
    public void StartRain()
    {
        StartCoroutine("IStartRain");
    }


    IEnumerator IStartRain()
    {
        audioSource.PlayDelayed(1f);
        audioSource.loop = true;
        while(audioSource.volume <= SoundMaxVol)
        {
            audioSource.volume += 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(UpSpeed);
        }
        while(audioSource.volume > SoundSmallVol)
        {
            audioSource.volume -= 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(DownSpeed);
        }
        gameObject.GetComponent<SoundControl>().enabled = true;
        bGM2.On();
    }

    public void On()
    {
        audioSource.PlayDelayed(1f);
        audioSource.loop = true;
        gameObject.GetComponent<SoundControl>().enabled = true;
    }
    /*
    #region Hello

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
                        gameObject.GetComponent<AudioSource>().volume -= smallVol * Time.deltaTime * 0.7f;
                        originVolum = GetComponent<AudioSource>().volume;
                    }
                    else
                    {
                        gameObject.GetComponent<AudioSource>().volume = smallVol;
                        originVolum = GetComponent<AudioSource>().volume;
                    }   //fdsf
                }
                else{
                    gameObject.GetComponent<AudioSource>().volume = 0.1f;
                }
            }
            else{
                if(gameObject.GetComponent<AudioSource>().volume != 1f)
                {
                    gameObject.GetComponent<AudioSource>().volume += smallVol * Time.deltaTime * 0.7f;
                    originVolum = GetComponent<AudioSource>().volume;
                }
            }
        }

    }
    #endregion
    */
}
