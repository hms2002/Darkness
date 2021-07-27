using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Canvas3DRaycaster : MonoBehaviour
{
    public Canvas m_Canvas;
    GraphicRaycaster m_gr;
    PointerEventData m_Ped;
    TextManager textManager;
    private RaycastHit hit;
    private Camera playerCam;
    private float distance = 4.5f;
    private bool Once = true;
    void Start()
    {
        playerCam = Camera.main;
        m_Ped = new PointerEventData(null);
        textManager = FindObjectOfType<TextManager>();
    }

    void Update()
    {
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Vector3 rayDir = playerCam.transform.forward;
        /*if(Physics.Raycast(rayOrigin, rayDir, out hit, distance, 1 << (LayerMask.NameToLayer("IntCanvas"))))
        {
            if(Once)
            {
                Once = false;
                m_Canvas = hit.transform.GetChild(0).gameObject.GetComponent<Canvas>();
                m_gr = m_Canvas.GetComponent<GraphicRaycaster>();

            }
            if(m_Canvas != null)
            {
                m_Ped.position = Input.mousePosition;
                List<RaycastResult> hits = new List<RaycastResult>();
                m_gr.Raycast(m_Ped, hits);        

                textManager.EUse();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(m_Canvas.transform.GetComponent<IItem>() != null)
                    {
                        m_Canvas.transform.GetComponent<IItem>().Interact();
                    }
                }
                
            }
            else
            {
                Debug.Log("NONE");
            }
        }
        else
        {
            m_Canvas = null;
            Once = true;
        }*/
    }
}
