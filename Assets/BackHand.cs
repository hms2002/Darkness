using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHand : MonoBehaviour
{
    public avataAnim game;
    private void OnEnable() {
        game.enabled = true;
    }
}
