using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperTwo : MonoBehaviour, IItem
{
    private GameObject triggerFive;
    private bool isUseKnife = false;
    private Inventory inventory;
    private void Start() {
        inventory = FindObjectOfType<Inventory>();
        triggerFive = GameObject.Find("TriggerFive");
        inventory.useKnife += UseKnife;
    }
    public void Interact()
    {
        if(isUseKnife)        triggerFive.SetActive(true);
    }

    public void UseKnife()
    {
        isUseKnife = true;
    }

}
