using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTest : MonoBehaviour
{
    public Light it;
    [Range(0, 100)]private float cnt = 0;
    [Range(0f, 1f)] public float Rplus;  
    [Range(0f, 1f)] public float Gminus;
    [Range(0f, 1f)] public float Bminus;
    [Range(0f, 3f)] public float delay;
    void Start()
    {
            StartCoroutine("CC");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CC()
    {
        Color col = it.color;
        while(col.r != 1|| col.g != 0|| col.b != 0)
        {
            if(col.r != 1)
                col.r += Rplus;
            if(col.g != 0)
                col.g -= Gminus;
            if(col.b != 0)
                col.b -= Bminus;
            cnt++;
            Debug.Log(cnt);
            if(cnt >= 100)//fd
            {
                if(col.r >= 1 || col.g <= 0|| col.b <= 0)
                {
                    col.r = 1f;
                    col.g = 0f;
                    col.b = 0f;
                    it.color = col;
                }
                else
                {
                    it.color = col;
                }
            }//
            else{
                it.color = col;
            }
            yield return new WaitForSeconds(delay);
        }
        StopAllCoroutines();
    }
}
