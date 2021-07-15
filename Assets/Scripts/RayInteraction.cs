using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayInteraction : MonoBehaviour
{
    private Camera playerCam;
    private float distance = 4.5f;
    private float targetDistance;
    private Transform objTransform;
    public bool eatDesk = false;
    public bool moveObj = false;
    private RaycastHit hit;
    private Inventory inv;
    private TextManager textManager;
    private GameObject hitObj;
    void Start()
    {
        playerCam = Camera.main;
        inv = FindObjectOfType<Inventory>();
        textManager = FindObjectOfType<TextManager>();
        inv.useKnife += ObjMoveOn; 
       // int layerMask  = (1 << LayerMask.NameToLayer("IntObj")) + (1 << LayerMask.NameToLayer("mannequin"));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Vector3 rayDir = playerCam.transform.forward;
        #region IntObj
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
        #endregion
        #region mannequin
        else if(Physics.Raycast(rayOrigin, rayDir, out hit, distance, 1 << (LayerMask.NameToLayer("mannequin"))))
        {
            inv.isMannequin();
            if(Input.GetKeyDown(KeyCode.E))
            {
                inv.StingSuspendShot();
            }
            inv.isMannquin = true;
        }
        #endregion
        #region EatDesk
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
        #endregion
        #region MoveObj
        else if(moveObj)
        {
            if(Physics.Raycast(rayOrigin, rayDir, out hit, 8, 1 << (LayerMask.NameToLayer("MoveObj"))))
            {
                textManager.Click();
                if(Input.GetMouseButtonDown(0))
                {
                    hitObj = hit.transform.gameObject;
                    hitObj.GetComponent<Rigidbody>().isKinematic = true;
                    objTransform = hitObj.transform;
                    targetDistance = hit.distance;

                    
                }
                if(Input.GetMouseButtonUp(0))
                {
                    hitObj.GetComponent<Rigidbody>().isKinematic = false;
                    hitObj = null;
                    objTransform = null;
                }
            }
            else
            {
                inv.isMannquin = false;
                textManager.TextClose();

            }
            if(objTransform != null)
            {
                if(Physics.Raycast(rayOrigin, rayDir, out hit, targetDistance, 1 << (LayerMask.NameToLayer("Buliding"))))
                {
                    objTransform.position = rayOrigin + rayDir * (hit.distance - 0.5f);
                    Debug.Log("DisTance : " + hit.distance);
                    Debug.Log("TargetDisTance : " + targetDistance);
                    Debug.Log("DisTance - TargetDistance : " + (hit.distance - 0.5f));
                }
                else{
                    objTransform.position = rayOrigin + rayDir * (targetDistance);
                }
            }
        }
        #endregion
        else
        {
            inv.isMannquin = false;
            textManager.TextClose();
        } 

    }

    public void ObjMoveOn()
    {
        moveObj = true;
    }
}
