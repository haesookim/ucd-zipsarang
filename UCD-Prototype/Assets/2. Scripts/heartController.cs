using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour
{
    void Awake(){
        Destroy(this.gameObject, 1f);
    }
}
