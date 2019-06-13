using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionBalloon : MonoBehaviour
{
    public animalController animalController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Debug.Log("running");
        //go to minigame
        animalController.raiseAffect();
    }
}
