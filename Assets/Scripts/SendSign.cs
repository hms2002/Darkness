using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSign : MonoBehaviour, IItem
{
    private GameObject parent;
    private void Start() {
        parent = transform.parent.gameObject;
    }
    public void Interact()
    {
        Newspaper news = parent.GetComponent<Newspaper>();
        news.Interact();        
    }
}
