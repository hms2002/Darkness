using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayInteraction : MonoBehaviour
{
    private Camera playerCam;
    private float distance = 4.5f;
    public bool eatDesk = false;
    private RaycastHit hit;
    private Inventory inv;
    private TextManager textManager;
    void Start()
    {
        playerCam = Camera.main;
        inv = FindObjectOfType<Inventory>();
        textManager = FindObjectOfType<TextManager>();
       // int layerMask  = (1 << LayerMask.NameToLayer("IntObj")) + (1 << LayerMask.NameToLayer("mannequin"));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Vector3 rayDir = playerCam.transform.forward;

        if(Physics.Raycast(rayOrigin, rayDir, out hit, distance, 1 << (LayerMask.NameToLayer("IntObj"))))
        {
            textManager.EUse();
            GameObject hitObject = hit.collider.gameObject;
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(hitObject == null)
                {
                    Debug.Log("!");
                    return;
                }
                IItem[] item = hitObject.GetComponents<IItem>();
                if(item == null)
                {
                    Debug.Log("!!");
                    return;
                }
                for(int i = 0; i < item.Length; i++)
                item[i].Interact();
            }
        }
        else if(Physics.Raycast(rayOrigin, rayDir, out hit, distance, 1 << (LayerMask.NameToLayer("mannequin"))))
        {
            inv.isMannequin();
            if(Input.GetKeyDown(KeyCode.E))
            {
                inv.StingSuspendShot();
            }
            inv.isMannquin = true;
        }
        else if(eatDesk)
        {
            if(Physics.Raycast(rayOrigin, rayDir, out hit, distance, 1 << (LayerMask.NameToLayer("EatDesk"))))
            {
                textManager.MeatSetting();
                GameObject hitObject = hit.collider.gameObject;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(hitObject == null)
                    {
                        Debug.Log("!");
                        return;
                    }
                    IItem item = hitObject.GetComponent<IItem>();
                    if(item == null)
                    {
                        Debug.Log("!!");
                        return;
                    }
                    item.Interact();
                }
            }
            else
            {
                inv.isMannquin = false;
                textManager.TextClose();
            } 
        }
        else
        {
            inv.isMannquin = false;
            textManager.TextClose();
        } 
    }
}
