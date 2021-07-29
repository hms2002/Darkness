using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeControler : MonoBehaviour
{
    public void ChangeVol(float percentage)
    {
        AudioListener.volume = percentage;
    }
}
