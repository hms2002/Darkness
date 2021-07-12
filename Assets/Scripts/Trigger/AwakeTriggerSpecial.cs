using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeTriggerSpecial : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.useRope += AwakeChild;
    }

    public void AwakeChild()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
