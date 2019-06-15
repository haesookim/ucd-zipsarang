using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class animalController : MonoBehaviour
{
    public Vector3 speed = new Vector3(300f, 0, 0);
    public bool nuggimpyo = false;
    public int affection = 0;

    public GameObject interactionBalloon;
    public GameObject interactionHeart;

    public int interval = 10;
    private int currTime = 0;
    private float timer;
    private int timeInSecs;
    private int rand = 2;

    public Camera Main;
    public Camera Focus;
    public Canvas MainUI;
    public Canvas FocusUI;

    private Animator anim;

    private float originYpos;
    private Vector3 positionVal;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        originYpos = gameObject.GetComponent<SpriteRenderer>().transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeInSecs = (int)(timer % 60);
        if (timeInSecs == 0)
        {
            currTime = 0;
        }
        if (timeInSecs - currTime >= interval)
        {
            currTime = timeInSecs;
            rand = (int)Random.Range(0, 7);
            positionVal = gameObject.GetComponent<SpriteRenderer>().transform.position;
            positionVal.y = originYpos;
            gameObject.GetComponent<SpriteRenderer>().transform.position = positionVal;
            interval = 10;
        }
        randomMovement(rand);

        if (timeInSecs == 10)
        {
            nuggimpyo = true;
        }

        if (nuggimpyo)
        {
            interactionBalloon.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            interactionBalloon.GetComponent<SpriteRenderer>().enabled = false;
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

    void OnMouseDown()
    {
        //camera switching script
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Main.enabled = false;
            Focus.enabled = true;
            MainUI.enabled = false;
            FocusUI.enabled = true;
        }
    }

    void randomMovement(int rand)
    {
        switch (rand)
        {
            case 0:
                move(0);
                anim.SetBool("stretching", false);
                anim.SetBool("sitting", false);
                anim.SetBool("moving", true);
                anim.SetBool("down", false);
                anim.SetBool("search", false);
                anim.SetBool("watching", false);
                break;

            case 1:
                move(1);
                anim.SetBool("stretching", false);
                anim.SetBool("sitting", false);
                anim.SetBool("moving", true);
                anim.SetBool("down", false);
                anim.SetBool("search", false);
                anim.SetBool("watching", false);
                break;

            case 2:
                //앉아있기
                anim.SetBool("moving", false);
                anim.SetBool("stretching", false);
                anim.SetBool("sitting", true);
                anim.SetBool("down", false);
                anim.SetBool("search", false);
                anim.SetBool("watching", false);
                break;

            case 3:
                //기지개
                anim.SetBool("moving", false);
                anim.SetBool("sitting", false);
                anim.SetBool("stretching", true);
                anim.SetBool("down", false);
                anim.SetBool("search", false);
                anim.SetBool("watching", false);
                interval = 2;
                break;
            case 4:
                //누워있기
                anim.SetBool("moving", false);
                anim.SetBool("sitting", false);
                anim.SetBool("stretching", false);
                anim.SetBool("down", true);
                anim.SetBool("search", false);
                anim.SetBool("watching", false);
                positionVal = gameObject.GetComponent<SpriteRenderer>().transform.position;
                positionVal.y = originYpos - 0.4f;
                gameObject.GetComponent<SpriteRenderer>().transform.position = positionVal;
                break;
            case 5:
                //구경하기
                anim.SetBool("moving", false);
                anim.SetBool("sitting", false);
                anim.SetBool("stretching", false);
                anim.SetBool("down", false);
                anim.SetBool("search", false);
                anim.SetBool("watching", true);
                interval = 3;
                break;
            case 6:
                //뒤적뒤적
                anim.SetBool("moving", false);
                anim.SetBool("sitting", false);
                anim.SetBool("stretching", false);
                anim.SetBool("down", false);
                anim.SetBool("search", true);
                anim.SetBool("watching", false);
                positionVal = gameObject.GetComponent<SpriteRenderer>().transform.position;
                positionVal.y = originYpos - 0.2f;
                gameObject.GetComponent<SpriteRenderer>().transform.position = positionVal;
                interval = 4;
                break;
        }
    }

    void move(int dir)
    {
        if (dir == 0)
        { // move left
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (gameObject.transform.position.x < -16)
            {
                rand = 1;
            }
            transform.Translate(-speed * Time.deltaTime);
        }
        else if (dir == 1)
        { // move right
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (gameObject.transform.position.x > 16)
            {
                rand = 0;
            }
            transform.Translate(speed * Time.deltaTime);
        }
    }

    public void raiseAffect()
    {
        float randx = Random.Range(-0.2f, 0.2f);
        Vector3 pos = new Vector3(randx, 2, 0);
        affection++; // 1~6 scale if affection < max
        nuggimpyo = false;
        Instantiate(interactionHeart, gameObject.transform.position + pos, Quaternion.identity);
    }

    void viewDetail()
    {
        Debug.Log("view Detail");
        nuggimpyo = false;
    }
}
