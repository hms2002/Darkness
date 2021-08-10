using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{
    public void MurderOn()
    {
        StartCoroutine("IMurder");
    }
    IEnumerator IMurder()
    {
        for(int i = 0; i < 28; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f - (i * 1.2f)/28);
        }
        
    }
}
