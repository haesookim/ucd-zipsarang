using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    
    void Start(){
        if(SceneManager.GetActiveScene().name.Equals("Discover") || SceneManager.GetActiveScene().name.Equals("Found")){
            Screen.SetResolution(1088, 2224, true);
            Screen.orientation = ScreenOrientation.Portrait;
        } else{
            Screen.SetResolution(2224, 1088, true);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }

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
