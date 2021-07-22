using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDesk : MonoBehaviour, IItem
{
    private Meat meat;
    public GameObject game;
    private bool isOnce = true;
    private void Start() {
        meat = FindObjectOfType<Meat>();
    }
    public void Interact()
    {
        if(isOnce)
        {
            game.transform.GetChild(1).gameObject.SetActive(true);
            isOnce = false;
            this.gameObject.layer = 6;
        }
    }
}
