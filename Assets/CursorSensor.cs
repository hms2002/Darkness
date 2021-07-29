using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorSensor : MonoBehaviour
{
    private Text text;
    private Color color;
    private void Start() {
        text = GetComponent<Text>();
        color = text.color;
    }
    private void OnMouseEnter() {
        text.color = new Color(200/255f, 92/255f, 92/255f);
    }

    private void OnMouseExit() {
        text.color = color;
    }
}
