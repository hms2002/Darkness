using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentOff : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
        gameObject.GetComponent<SpecialNewspaper>().enabled = false;
        inventory = FindObjectOfType<Inventory>();
        inventory.useRope += ComponentOn;
        this.gameObject.layer = 6;
    }

    public void ComponentOn()
    {
        gameObject.GetComponent<SpecialNewspaper>().enabled = true;
        this.gameObject.layer = 7;

    }
}
