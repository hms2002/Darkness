using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFloorGhost : MonoBehaviour
{  
    private void Awake() {
        transform.parent.gameObject.GetComponent<LightPibot4Sound>().Playing();
    }
}
