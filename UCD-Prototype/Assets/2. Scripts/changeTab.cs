using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTab : MonoBehaviour
{
    public Sprite tab1;
    public Sprite tab2;
    public Sprite tab3;
    public Sprite tab4;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;


    public void showTab1(){
        this.GetComponent<SpriteRenderer>().sprite = tab1;
        canvas1.enabled = true;
        canvas2.enabled = false;
        canvas3.enabled = false;
        canvas4.enabled = false;
    }

    public void showTab2(){
        this.GetComponent<SpriteRenderer>().sprite = tab2;
        canvas1.enabled = false;
        canvas2.enabled = true;
        canvas3.enabled = false;
        canvas4.enabled = false;
    }

    public void showTab3(){
        this.GetComponent<SpriteRenderer>().sprite = tab3;
        canvas1.enabled = false;
        canvas2.enabled = false;
        canvas3.enabled = true;
        canvas4.enabled = false;
    }

    public void showTab4(){
        this.GetComponent<SpriteRenderer>().sprite = tab4;
        canvas1.enabled = false;
        canvas2.enabled = false;
        canvas3.enabled = false;
        canvas4.enabled = true;
    }
}
