using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorSensorMain : MonoBehaviour
{
    private GameManager gameManager;
    private SceneGameManager scene;
    public GameObject optionCanvas;
    private Text text;
    private Color color = new Color(0,0,0);
    public int index;
    private bool Once = true;
    private bool isSettingOn = false;
    private void Awake() {
        text = GetComponent<Text>();
        Once = false;
    }
    private void OnEnable() {
        Debug.Log("Go");
        text.color = Color.white;
    }
    private void Start() {
        scene = FindObjectOfType<SceneGameManager>();
        gameManager = FindObjectOfType<GameManager>();
        color = text.color;
    }
    private void Update() {
        if(isSettingOn)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                optionCanvas.SetActive(false);
                gameManager.isCanESC = true;
                isSettingOn = false;
                text.color = Color.white;

            }
        }
    }

    private void OnMouseEnter() {
        if(isSettingOn == false)
        {
            text.color = new Color(200/255f, 92/255f, 92/255f);
        }
    }

    private void OnMouseDown() {
        if(isSettingOn == false)
        {
            text.color = Color.gray;
        }
    }

    private void OnMouseUp() {
        if(isSettingOn == false)
        {
            text.color = new Color(253/255f, 92/255f, 92/255f);
            
            switch(index)
            {
                case 1:
                    gameManager.Continue();
                break;
                case 2:
                    optionCanvas.SetActive(true);
                    gameManager.isCanESC = false;
                    isSettingOn = true;
                break;
                case 3:
                    scene.GoScene1();
                break;
            }
        }
    }

    private void OnMouseExit() {
        if(isSettingOn == false)
        {
            text.color = color;
        }
    }


}
