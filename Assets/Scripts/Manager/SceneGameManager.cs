using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneGameManager : MonoBehaviour
{
    private FadeManager fadeManager;

    private void Start() {
        fadeManager = FindObjectOfType<FadeManager>();
        fadeManager.SceneMoveAction += GoScene2;
    }

    public void GoScene2()
    {
        SceneManager.LoadScene("Scene");
    } 

    public void GoScene3()
    {
        SceneManager.LoadScene("Darkness");
    }  

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif        

        
    }
}
