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

        public int touchToUnlock = 20;
        private int touchCount = 0;
        public Slider touchSlider;


        // Start is called before the first frame update
        void Start()
        {
            arCamera = Camera.main;
            touchSlider.maxValue = touchToUnlock;
        }

        // Update is called once per frame
        void Update()
        {
            updateTimer();

            Touch touch = Input.GetTouch(0);
            if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
            {
                // TrackableHit hit;
                // TrackableHitFlags flags = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;

                // //ARCore Raycast
                // if (Frame.Raycast(touch.position.x, touch.position.y, flags, out hit))
                // {
                //     var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                //     Instantiate(loaded, hit.Pose.position, hit.Pose.rotation, anchor.transform);
                // }

                touchCount++;
                touchSlider.value = touchCount;
            }
        }

        void updateTimer(){
            timer += Time.deltaTime;
         // turn seconds in float to int
            timeInSecs = (int)(timer % 60);
            if (timeInSecs<15){
                timeText.text = "" + (timeLimit - timeInSecs);
            }
        }
    }
}
