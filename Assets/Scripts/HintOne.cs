using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintOne : MonoBehaviour, IItem
{
    private HintManager hint;
    private TextManager textManager;
    public int HintNum;
    
    private bool Once = true;

    void Start()
    {
        hint = FindObjectOfType<HintManager>();    
        textManager = FindObjectOfType<TextManager>();
    }

    public void Interact()
    {
        if(Once)
        {
            Once = false;
            if(hint.KnifeHintOn || hint.RopeHintOn || hint.GunHintOn)
            {
                textManager.OtherTextOn(10);
            }
            else
            {
                textManager.OtherTextOn(9);
            }
            hint.GetHint(HintNum);
            gameObject.SetActive(false);
        }
    }
}
