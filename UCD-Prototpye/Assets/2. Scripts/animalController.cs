using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalController : MonoBehaviour
{
    public Vector3 speed = new Vector3(300f,0,0);
    public int affection;

    public int interval = 3;
    private int currTime = 0;
    private float timer;
    private int timeInSecs;
    private int rand = 2;

    public Sprite sitting;
    public Sprite stretching;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* ontouch{
            if (nuggimpyo){
                raiseAffect();
            }
            else{
                viewDetail();
            }
        }*/

        timer += Time.deltaTime;
        timeInSecs = (int)(timer % 60);

        if (timeInSecs - currTime >= interval){
            currTime = timeInSecs;
            rand = (int)Random.Range(0,4);
            Debug.Log(rand);
        }
        randomMovement(rand);
    }

    void randomMovement(int rand){
        switch (rand){
            case 0 : 
                move(0);
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                break;

            case 1:
                move(1); 
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                break;

            case 2:
                //앉아있기
                gameObject.GetComponent<SpriteRenderer>().sprite = sitting;
                gameObject.GetComponent<Animator>().SetBool("moving", false);
                break;
            
            case 3:
                //기지개
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = stretching;
                gameObject.GetComponent<Animator>().SetBool("moving", false);
                break;
        }
    }

    void move(int dir){
        if (dir == 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(-speed * Time.deltaTime);
        } else if (dir ==1){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(speed * Time.deltaTime);    
        }
    }

    void raiseAffect(){
        affection++; // 1~6 scale if affection < max
    }
}
