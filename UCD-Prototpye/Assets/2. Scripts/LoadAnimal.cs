namespace GoogleARCore
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GoogleARCore;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = InstantPreviewInput;
#endif

    public class LoadAnimal : MonoBehaviour
    {
        public Camera arCamera;
        public GameObject loaded;

        public Text timeText;
        public int timeLimit = 15;
        private float timer = 0.0f;
        private int timeInSecs = 0;
        private bool timerActive = false;

        public int touchToUnlock = 20;
        private int touchCount = 0;
        public Slider touchSlider;
        private bool touchActive;

        // Start is called before the first frame update
        void Start()
        {
            arCamera = Camera.main;
            touchSlider.maxValue = touchToUnlock;
        }

        // Update is called once per frame
        void Update()
        {
            bool buttonPressed = true;
            if (buttonPressed)
            {
                touchCount = 0;
                touchActive = true;
                //also make slider visible
            }

            if (timerActive)
            { //timeractive becomes true when button is pressed
                updateTimer();
                if (touchCount == touchToUnlock)
                {
                    // make slider invisible
                    // state moves to TAKE_HOME
                }
            }

            Touch touch = Input.GetTouch(0);
            if (touchActive)
            {
                if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
                {
                    touchCount++;
                    touchSlider.value = touchCount;
                }
            }
        }

        void updateTimer()
        {
            timer += Time.deltaTime;
            // turn seconds in float to int
            timeInSecs = (int)(timer % 60);
            if (timeInSecs <= timeLimit)
            {
                timeText.text = "" + (timeLimit - timeInSecs);
            }
            else
            {
                timerActive = false;
            }
        }
    }
}
