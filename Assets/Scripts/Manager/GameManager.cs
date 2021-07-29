using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    /*#region ;;
    public Image fadeImage;

    public void GameStart()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a+0.01f;
            fadeImage.color =  startColor;
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene("InPlayerHouse");
    }
    #endregion
*/
    private RayInteraction rayInteraction;
    private FirstPersonController firstPersonController;
    public GameObject ESCCanvas;
    public GameObject Crosshair;
    public Camera ESCcamera;
    private Camera PlayerCam;
    private bool isMenuOpen = false;
    public bool isCanESC = true;

    private void Start() {
        PlayerCam = Camera.main;
        rayInteraction = FindObjectOfType<RayInteraction>();
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && isMenuOpen == false)
        {
            Crosshair.SetActive(false);
            ESCcamera.enabled = true;
            PlayerCam.enabled = false;
            isMenuOpen = true;
            rayInteraction.enabled = false;
            firstPersonController.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            ESCCanvas.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isMenuOpen == true && isCanESC)
        {
            Crosshair.SetActive(true);
            ESCcamera.enabled = false;
            PlayerCam.enabled = true;
            isMenuOpen = false;
            rayInteraction.enabled = true;
            firstPersonController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            ESCCanvas.SetActive(false);
        }
    }

    public void Continue()
    {
        Debug.Log("dsd");
        Crosshair.SetActive(true);
        ESCcamera.enabled = false;
        PlayerCam.enabled = true;
        isMenuOpen = false;
        rayInteraction.enabled = true;
        firstPersonController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        ESCCanvas.SetActive(false);
    }
}
