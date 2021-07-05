using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHouseGoNextScene : MonoBehaviour
{
    public AudioClip doorKickClip;
    private AudioSource sceneStartSound;
    private void Start() {
        sceneStartSound = GetComponent<AudioSource>();
        sceneStartSound.PlayOneShot(doorKickClip);
    }
    public void NextScene()
    {
        StartCoroutine("Next");
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BeforeDarkness");
    }
}
