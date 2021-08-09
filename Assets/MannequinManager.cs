using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinManager : MonoBehaviour
{
    private Inventory inv;
    private SafeUIManager safe;

    void Start()
    {
        inv = FindObjectOfType<Inventory>();    
        safe = FindObjectOfType<SafeUIManager>();
        inv.useKnife += Knife;
        safe.BackAction += Back;
        inv.useRope += Rope;
    
    }

    public void Knife()
    {
        StartCoroutine("IKnife");
    }
    public void SetBack()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
    

    public void Back()
    {
        StartCoroutine("IBack");
    }

    public void Rope()
    {
        StartCoroutine("IRope");
    }

    IEnumerator IKnife()
    {
        yield return new WaitForSeconds(1.5f);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);

    }
    IEnumerator IBack()
    {
        yield return new WaitForSeconds(1.5f);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    IEnumerator IRope()
    {
        yield return new WaitForSeconds(1.5f);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        
    }
    
}
