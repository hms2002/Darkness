using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintOn : MonoBehaviour
{
    public GameObject Paint;

    private void OnTriggerEnter(Collider other) {
        Paint.SetActive(true);
    }
}
