using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeControler : MonoBehaviour
{
    private SettingMember settingMember;
    private void Start() {
        settingMember = FindObjectOfType<SettingMember>();
        if(settingMember != null)
        {
            settingMember.Reset();
            settingMember.LinkSetting();
        }
    }
    public void ChangeVol(float percentage)
    {
        if(settingMember != null)
        {
            settingMember.LinkSetting(percentage);
        }
    }
}
