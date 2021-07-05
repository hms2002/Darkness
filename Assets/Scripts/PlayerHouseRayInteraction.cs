using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHouseRayInteraction : MonoBehaviour
{
    private Camera playerCam;
    private float distance = 4.5f;
    private RaycastHit hit;
    public Inventory inv;
    public GameObject text;
    void Start()
    {
        playerCam = Camera.main;
       // int layerMask  = (1 << LayerMask.NameToLayer("IntObj")) + (1 << LayerMask.NameToLayer("mannequin"));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Vector3 rayDir = playerCam.transform.forward;

        if(Physics.Raycast(rayOrigin, rayDir, out hit, distance, 1 << (LayerMask.NameToLayer("mannequin")) | 1 << (LayerMask.NameToLayer("IntObj"))))
        {
            text.SetActive(true);
            GameObject hitObject = hit.collider.gameObject;
            if(Input.GetKeyDown(KeyCode.E))
            {
                
                inv.isMannequin();
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
            if(hitObject.CompareTag("mannequin"))
            {
                inv.isMannquin = true;
            }
            else inv.isMannquin = false;
        }
        else             text.SetActive(false);
    }
}
