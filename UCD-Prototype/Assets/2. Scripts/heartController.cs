using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour
{
    private Vector3 speed = new Vector3 (0, 0.5f, 0);

    void Awake(){
        Destroy(this.gameObject, 1f);
    }

    void Update(){
        transform.Translate(speed * Time.deltaTime); 
    }
}
