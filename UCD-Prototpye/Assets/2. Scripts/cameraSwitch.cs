using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public Camera Main;
    public Camera Focus;
    public Canvas MainUI;
    public Canvas FocusUI;

    public void switchCam(){
        Main.enabled = true;
        Focus.enabled = false;
        MainUI.enabled = true;
        FocusUI.enabled = false;
    }
}
