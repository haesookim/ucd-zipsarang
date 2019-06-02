using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void toPlayRoom(){
        SceneManager.LoadScene("Playroom");
    }

    public void toShop(){
        SceneManager.LoadScene("Shop");
    }

    public void toGallery(){
        SceneManager.LoadScene("Gallery");
    }

    public void toEmergency(){
        SceneManager.LoadScene("Emergency");
    }
    
    public void toSettings(){
        SceneManager.LoadScene("Settings");
    }
}
