using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private FadeManager fadeManager;
    private SceneGameManager scene;
    void Start()
    {
        fadeManager = FindObjectOfType<FadeManager>();
        scene = FindObjectOfType<SceneGameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
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
