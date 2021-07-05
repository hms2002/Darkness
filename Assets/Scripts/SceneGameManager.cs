using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneGameManager : MonoBehaviour
{
    public void GoScene2()
    {
        SceneManager.LoadScene("InPlayerHouse");
    } 

    public void GoScene3()
    {
        SceneManager.LoadScene("BeforeDarkness");
    }

    public void GoScene4()
    {
        SceneManager.LoadScene("SampleScene");
    }  
}
