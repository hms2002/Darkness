using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioclip;
    private FadeManager fadeManager;
    private SceneGameManager scene;
    void Start()
    {
        fadeManager = FindObjectOfType<FadeManager>();
        scene = FindObjectOfType<SceneGameManager>();

    }

    public void ExitGame()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioclip);
        fadeManager.FadeIn();
        StartCoroutine("Out");
    }

    IEnumerator  Out() {
        {
            yield return new WaitForSeconds(1.5f);
            scene.Exit();
        }
    }
}
