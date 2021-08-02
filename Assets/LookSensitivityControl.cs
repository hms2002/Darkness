using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookSensitivityControl : MonoBehaviour
{
    private SettingMember settingMember;
    private void Start() {
        settingMember = FindObjectOfType<SettingMember>();
        if(settingMember != null)
        {
            settingMember.Reset();
            settingMember.HandleSetting();
        }
    }

    public void ChangeVol(float percentage)
    {
        if(settingMember != null)
        {
            settingMember.HandleSetting(percentage);
        }
    }
}
