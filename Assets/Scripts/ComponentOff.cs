using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentOff : MonoBehaviour
{
    private Inventory inventory;
    private plusLastSpecialDoor lastSpecialDoor;
    void Start()
    {
        gameObject.GetComponent<SpecialNewspaper>().enabled = false;
        inventory = FindObjectOfType<Inventory>();
        inventory.useRope += ComponentOn;
        this.gameObject.layer = 6;
        if(lastSpecialDoor != null)
        {
            lastSpecialDoor.goAnotherWorld2 += ComponentOffF;
        }
    }

    public void ComponentOn()
    {
        gameObject.GetComponent<SpecialNewspaper>().enabled = true;
        this.gameObject.layer = 7;
        gameObject.GetComponent<SpecialNewspaper>().afterUseRope = true;
    }

    public void ComponentOffF()
    {
        gameObject.GetComponent<SpecialNewspaper>().enabled = false;
        this.gameObject.layer = 6;

    }
}
