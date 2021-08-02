using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMember : MonoBehaviour
{
    public static float volume = 1;
    public static float handle = 2;
    private FirstPersonController firstPersonController;
    
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Reset()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    public void LinkSetting()
    {
        AudioListener.volume = volume;
    }

    public void LinkSetting(float percentage)
    {
        AudioListener.volume = percentage;
        volume = AudioListener.volume;
    }

    public void HandleSetting()
    {
        if(firstPersonController != null)
        {
            firstPersonController.mouseSensitivity = handle;
        }
    }


    public void HandleSetting(float percentage)
    {
        if(firstPersonController != null)
        {
            firstPersonController.mouseSensitivity = percentage * 10;
        }
        handle = percentage * 10;
    }
}
