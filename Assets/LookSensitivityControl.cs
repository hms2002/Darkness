using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookSensitivityControl : MonoBehaviour
{
    private FirstPersonController firstPersonController;
    private void Start() {
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    public void ChangeVol(float percentage)
    {
        firstPersonController.mouseSensitivity = percentage * 10;
    }
}
