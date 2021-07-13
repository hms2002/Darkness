using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildKitchinDrawer : MonoBehaviour, IItem
{
    public GameObject drawerPibot;
    private KitchinDrawer kitchinDrawer;
    private void Start() {
        kitchinDrawer = drawerPibot.GetComponent<KitchinDrawer>();
    }
    public void Interact()
    {
        kitchinDrawer.Interact();
    }
}
