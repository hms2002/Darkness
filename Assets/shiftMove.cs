using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftMove : MonoBehaviour
{
    Vector3 targetPos = new Vector3(0, 0.24f, 0);
    Vector3 nomalPos = new Vector3(0, 0.24f, 0f);
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(verticalInput != 0 || horizontalInput != 0)
            {
                Debug.Log("DD");
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, 0.9f);
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("ff");
            transform.localPosition = Vector3.Lerp(transform.localPosition, nomalPos, 0.1f);

        }
    }
}
