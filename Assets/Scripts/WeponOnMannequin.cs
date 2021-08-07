using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponOnMannequin : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.useKnife += EmbedKnife;
        inventory.useRope += EmbedRope;
    }

    public void EmbedKnife()
    {
        StartCoroutine("IEmbedKnife");
    }

    public void EmbedRope()
    {
        StartCoroutine("IEmbedRope");
    }

    IEnumerator IEmbedKnife()
    {
        yield return new WaitForSeconds(1);
        transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    IEnumerator IEmbedRope()
    {
        yield return new WaitForSeconds(1);
        transform.parent.GetChild(3).gameObject.SetActive(true);
    }
}
