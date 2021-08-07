using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAnim : MonoBehaviour
{
    public Animator anim;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }

        float verticalnput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        anim.SetFloat("Speed", verticalnput);
        anim.SetFloat("Horizontal", horizontalInput);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(verticalnput != 0 || horizontalInput != 0)
            {
                anim.SetBool("IsRunning", true);
            }
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("IsRunning", false);
        }
    }
}
