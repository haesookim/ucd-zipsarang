using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void toGone(){
        SceneManager.LoadScene("Gone");
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

    public void toDetails(){
        SceneManager.LoadScene("Details");
    }

    public void toDetailsPoodle(){
        SceneManager.LoadScene("DetailsPoodle");
    }

    public void toEmergency(){
        SceneManager.LoadScene("Emergency");
    }
    
    public void toPayment(){
        SceneManager.LoadScene("Payment");
    }

    public void toFound(){
        SceneManager.LoadScene("Found");
    }

    public void toFoundPoodle(){
        SceneManager.LoadScene("FoundPoodle");
    }

    public void toTitle(){
        SceneManager.LoadScene("TitleScreen");
    }
}
