using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private SpecialNewspaper specialNewspaper;
    void Start()
    {
        specialNewspaper = FindObjectOfType<SpecialNewspaper>();
        specialNewspaper.goAnotherWorld += MoveRoom;
    }

    public void MoveRoom()
    {
        transform.position += new Vector3(-51, 0, 0);
    }
}
