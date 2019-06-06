namespace GoogleARCore
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GoogleARCore;
    using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = InstantPreviewInput;
#endif

    public class LoadAnimal : MonoBehaviour
    {
        public Camera arCamera;
        public GameObject catModel;

        public Text timeText;
        public int timeLimit;
        private float timer = 0.0f;
        private int timeInSecs = 0;
        private int timeRemaining;
        private bool timerActive = true;

        public int touchToUnlock;
        private int touchCount = 0;
        public Slider touchSlider;
        private bool touchCounting = true;

        bool buttonPressed;
        public GameObject button;

        public GameObject hearts;
        public Text successText;
        public Text failText;

        // Start is called before the first frame update
        void Start()
        {
            arCamera = Camera.main;
            touchSlider.maxValue = touchToUnlock;
            spawnWithoutPlane();
        }

        // Update is called once per frame
        void Update()
        {
            // if (timeInSecs == 3)
            // { // change this into a button interaction moment
            //     buttonPressed = true;
            //     timerActive = false;
            // }
            // if (buttonPressed)
            // {
            //     touchCount = 0;
            //     touchCounting = true;
            //     buttonPressed = false;
            //     timerActive = true;

            //     //show slider & text but hide button
            //     foreach (Image a in touchSlider.GetComponentsInChildren<Image>())
            //     {
            //         a.enabled = true;
            //     }
            //     timeText.enabled = true;
            //     button.GetComponentInChildren<Image>().enabled = false;
            //     button.GetComponentInChildren<Text>().enabled = false;
            // }

            // if (timerActive)
            // { //timeractive becomes true when button is pressed
            //     updateTimer();
            //     if (touchCount == touchToUnlock)
            //     {
            //         touchCounting = false;
            //         Debug.Log("We won!");
            //         timeText.enabled = false;
            //         successText.enabled = true;

            //         timerActive = false;
            //         foreach (Image a in touchSlider.GetComponentsInChildren<Image>())
            //         {
            //             a.enabled = false;
            //         }
            //     }
            //     else if (timeRemaining == 0)
            //     {
            //         Debug.Log("You failed");
            //         timerActive = false;
            //     }
            // }

            Touch touch = Input.GetTouch(0);
            if (touchCounting)
            {
                // if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
                // {
                //     touchCount++;
                //     touchSlider.value = touchCount;
                //     loadHeart(touch);
                // }

                // if (touchCount == touchToUnlock){
                //     touchCounting = false;
                //     Debug.Log("We won!");
                //     //timeText.enabled = false;
                //     successText.enabled = true;

                //     //timerActive = false;
                //     foreach (Image a in touchSlider.GetComponentsInChildren<Image>())
                //     {
                //         a.enabled = false;
                //     }
                // }

                if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
                {
                    touchCount++;
                }

                if (touchCount > 1){
                    SceneManager.LoadScene("Found");
                }

            }

        }

        void updateTimer()
        {
            timer += Time.deltaTime;
            // turn seconds in float to int
            timeInSecs = (int)(timer % 60);
            timeRemaining = timeLimit - timeInSecs;
            if (timeInSecs <= timeLimit)
            {
                timeText.text = "" + timeRemaining;
            }
            else
            {
                timerActive = false;
            }
            Debug.Log(timeRemaining);
        }

        void loadHeart(Touch touch)
        {
            Vector3 position = touch.position;
            position.z = 150;
            Vector3 objPos = Camera.main.ScreenToWorldPoint(position);
            Instantiate(hearts, objPos, Quaternion.identity);
        }

        void spawnWithoutPlane()
        {
            Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 3);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(position);
            Instantiate(catModel, objPos, Quaternion.identity);
        }

        // void spawn()
        // {
        //     RaycastHit hit;
        //     Ray spawnRay = arCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        // LayerMask selectLayers = 1 << LayerMask.NameToLayer(DetectedPlanesLayer);
        // if (loaded == null && Physics.Raycast(spawnRay, out hit, Mathf.Infinity, spawnLayers))
        // {
        //     loaded = Instantiate(catModel, hit.point, Quaternion.identity);
        // }
        // }
    }
}
