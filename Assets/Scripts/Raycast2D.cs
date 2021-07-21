using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Raycast2D : MonoBehaviour
{

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D start = Physics2D.GetRayIntersection(ray,Mathf.Infinity, 1 << (LayerMask.NameToLayer("MainUI")));
        RaycastHit2D exit = Physics2D.GetRayIntersection(ray,Mathf.Infinity, 1 << (LayerMask.NameToLayer("MainUIExit")));
        
        //Start
        if(Input.GetMouseButtonDown(0))
        {
            if(start)
            {
                text = start.collider.gameObject.GetComponent<Text>();
                text.color = Color.gray;
                Debug.Log("DAAS");
            }
            Debug.Log("DAAfdsfS");
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(start && start.collider.gameObject.layer == 11)
            {
                text.color = Color.red;
            }
            else if(text != null && text.gameObject.layer == 11)
            {
                text.color = new Color(253/255f, 92/255f, 92/255f);
                Debug.Log("DdsfAAS");
            }

        }
        //Exit
        if(Input.GetMouseButtonDown(0))
        {
            if(exit)
            {
                text = exit.collider.gameObject.GetComponent<Text>();
                text.color = Color.gray;
                Debug.Log("DAAS");
            }
            Debug.Log("DAAfdsfS");
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(exit && exit.collider.gameObject.layer == 12)
            {
                text.color = Color.white;
            }
            else if(text != null && text.gameObject.layer == 12)
            {
                text.color = new Color(253/255f, 92/255f, 92/255f);
                Debug.Log("DdsfAAS");
            }

        }

    }
}
/*
    if(gameobj.layer == menu)
    {

    }
*/