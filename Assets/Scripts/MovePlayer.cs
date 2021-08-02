using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private SpecialNewspaper specialNewspaper;
    private plusLastSpecialDoor plusLast;
    private float ax;
    private float ay;
    private float az;
    void Start()
    {
        specialNewspaper = FindObjectOfType<SpecialNewspaper>();
        plusLast = FindObjectOfType<plusLastSpecialDoor>();
        if(specialNewspaper != null)
        {
            specialNewspaper.goAnotherWorld += MoveRoom;
        }
        if(plusLast != null)
        {
            plusLast.goAnotherWorld2 += ComeBack;//fd
        }
    }

    public void MoveRoom()
    {
        ax = transform.position.x;
        ay = transform.position.y;
        az = transform.position.z;
        transform.position += new Vector3(0, 0, -46);
    }

    public void ComeBack()
    {
        transform.position = new Vector3(ax, ay, az);
    }
}
