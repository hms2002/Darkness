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
    }

    public void EmbedKnife()
    {
        StartCoroutine("IEmbedKnife");
    }

    IEnumerator IEmbedKnife()
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
