using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTwoOn : MonoBehaviour, IItem
{
    private GameObject triggerTwo;
    private GameObject triggerFour;

    private Knife knife;
    private bool Once = true;
    private void Start() {
        triggerTwo = GameObject.Find("TriggerTwo");
        triggerFour = GameObject.Find("TriggerFour");
        knife = FindObjectOfType<Knife>();
    }
    public void Interact()
    {
        if(Once){
            triggerTwo.gameObject.SetActive(true);
            triggerFour.gameObject.SetActive(true);
            knife.CanGet();
            Once = false;
        }
    }
}
