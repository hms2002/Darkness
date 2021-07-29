using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneGameManager : MonoBehaviour
{
    private FadeManager fadeManager;
    private Inventory inventory;

    private void Start() {
        inventory = FindObjectOfType<Inventory>();
        fadeManager = FindObjectOfType<FadeManager>();
        fadeManager.SceneMoveAction += GoScene2;
    }
    
    public void GoScene1()
    {
        SceneManager.LoadSceneAsync(0);
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

    IEnumerator fd()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadSceneAsync(0);
    }
}
