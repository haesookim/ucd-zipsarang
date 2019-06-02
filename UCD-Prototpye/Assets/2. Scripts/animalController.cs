using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class animalController : MonoBehaviour
{
    public Vector3 speed = new Vector3(300f,0,0);
    public bool nuggimpyo = false;
    public int affection = 0;

    public int interval = 5;
    private int currTime = 0;
    private float timer;
    private int timeInSecs;
    private int rand = 2;

    public Sprite sitting;
    public Sprite stretching;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
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
        if (timeInSecs == 0) {
            currTime = 0;
        }
        if (timeInSecs - currTime >= interval){
            currTime = timeInSecs;
            rand = (int)Random.Range(0,4);
            Debug.Log(rand);
        }
        randomMovement(rand);
        if (timeInSecs == 50) {
            nuggimpyo = true;
        }

        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos2D = new Vector2(touchPos.x , touchPos.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(touchPos2D, Camera.main.transform.forward);
            if (hitInfo.collider != null) {
                GameObject touchedObj = hitInfo.transform.gameObject;
                
            }
        }*/
        
    }

    void OnMouseDown() {
        Debug.Log("Meow");
        if (nuggimpyo == true) {
            raiseAffect();
        }
        else {
            Debug.Log("Detail info");
        }
        Debug.Log(affection);
    }

    void randomMovement(int rand){
        switch (rand){
            case 0 : 
                move(0);
                gameObject.GetComponent<Animator>().SetBool("stretching", false);
                gameObject.GetComponent<Animator>().SetBool("sitting", false);
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                break;

            case 1:
                move(1);
                gameObject.GetComponent<Animator>().SetBool("stretching", false);
                gameObject.GetComponent<Animator>().SetBool("sitting", false);
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                break;

            case 2:
                //앉아있기
                gameObject.GetComponent<Animator>().SetBool("moving", false);
                gameObject.GetComponent<Animator>().SetBool("stretching", false);
                gameObject.GetComponent<Animator>().SetBool("sitting", true);
                break;
            
            case 3:
                //기지개
                gameObject.GetComponent<Animator>().SetBool("moving", false);
                gameObject.GetComponent<Animator>().SetBool("sitting", false);
                gameObject.GetComponent<Animator>().SetBool("stretching", true);
                break;
        }
    }

    void move(int dir){
        if (dir == 0){ // move left
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (gameObject.transform.position.x < -1000 ) {
                rand = 1;
            }
            transform.Translate(-speed * Time.deltaTime);
        } else if (dir ==1){ // move right
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (gameObject.transform.position.x > 1000) {
                rand = 0;
            }
            transform.Translate(speed * Time.deltaTime);    
        }
    }

    void raiseAffect(){
        affection++; // 1~6 scale if affection < max
    }

    void viewDetail() {
        Debug.Log("view Detail");
        nuggimpyo = false;
    }
}
