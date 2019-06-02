using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmAdopt : MonoBehaviour
{
    public Canvas confirmUI;

    public void okay(){
        confirmUI.enabled = true;
    }
}
